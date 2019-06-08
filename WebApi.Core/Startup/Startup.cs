using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Castle.DynamicProxy;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
//using StackExchange.Profiling.Storage;
using Swashbuckle.AspNetCore.Swagger;
using WebApi.Core.AOP;
using WebApi.Core.AutoMapper;
using WebApi.Core.Common;
using WebApi.Core.Filter;
using WebApi.Core.LogHelper;
using WebApi.Core.Repository;
using WebApi.Core.Service;
using WebApi.Core.SwaggerHelper;

namespace WebApi.Core.Startup
{
    /// <summary>
    /// 启动项
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// log4net 仓储库
        /// </summary>
        public static ILoggerRepository repository { get; set; }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //log4net
            repository = LogManager.CreateRepository(ConstString.AppName);
            //指定配置文件
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
        }

        /// <summary>
        /// 程序集配置
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            #region log日志注入

            services.AddSingleton<ILogHelper, LogHelper.LogHelper>();

            #endregion

            #region Automapper

            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(AutoModule));

            #endregion

            #region 跨域CORS

            services.AddCors(c => {
                c.AddPolicy("LimitRequests", policy => {
                    policy
                    .WithOrigins(AppSettings.AppSettings.Apps("LimitRequests", "Url"))
                    .AllowAnyHeader()//Ensures that the policy allows any header.
                    .AllowAnyMethod();
                });
            });

            #endregion

            #region Swagger UI Service

            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            services.AddSwaggerGen(c => {
                //遍历出全部的版本，做文档信息展示
                typeof(ApiVersions).GetEnumNames().ToList().ForEach(version => {
                    c.SwaggerDoc(version, new Info
                    {
                        Version = version,
                        Title = $"{ConstString.AppName} 接口文档",
                        Description = $"{ConstString.AppName} HTTP API " + version,
                        TermsOfService = "None",
                        Contact = new Contact { Name = $@"{ConstString.AppName}", Email = "gongl01@mingyuanyun.com", Url = "https://open.mingyuanyun.com/docs/" }
                    });
                    c.OrderActionsBy(o => o.RelativePath);
                });

                //获取当前程序集执行DLL
                //string dllPath = Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath);                
                var xmlPath = Path.Combine(basePath, "WebApi.Core.xml");
                c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释
            });

            #endregion

            #region MVC + GlobalExceptions

            //注入全局异常捕获
            services.AddMvc(o => {
                o.Filters.Add(typeof(GlobalExceptionsFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #endregion

            #region AutoFac DI

            //实例化 AutoFac  容器   
            var builder = new ContainerBuilder();

            //注册一个单例日志组件
            builder.RegisterType<LogHelper.LogHelper>().As<ILogHelper>().SingleInstance();

            #region 带有接口层的服务注入


            var interceptors = GetAssemblyTypes(typeof(IInterceptor));
            builder.RegisterTypes(interceptors).AsSelf().PropertiesAutowired();

            var excuteAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            //服务注入
            Type service = typeof(IServiceBase);
            builder.RegisterAssemblyTypes(excuteAssembly)
                .Where(type => service.IsAssignableFrom(type) && !type.IsAbstract)
                .AsSelf().AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerLifetimeScope()
                .EnableClassInterceptors().InterceptedBy(typeof(ApiWatcher), typeof(ApiExecuteLogger));

            //仓储注入
            Type repository = typeof(IRepository<>);
            builder.RegisterAssemblyTypes(excuteAssembly)
                .Where(type => repository.IsAssignableFrom(type) && !type.IsAbstract)
                .AsSelf().AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerLifetimeScope()
                .EnableClassInterceptors().InterceptedBy(typeof(ApiExecuteLogger));           

            #endregion

            //将services填充到Autofac容器生成器中
            builder.Populate(services);

            //使用已进行的组件登记创建新容器
            var applicationContainer = builder.Build();

            #endregion

            return new AutofacServiceProvider(applicationContainer);//第三方IOC接管 core内置DI容器
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region Environment

            if (env.IsDevelopment())
            {
                // 在开发环境中，使用异常页面，这样可以暴露错误堆栈信息，所以不要放在生产环境。
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseExceptionHandler("/Error");
                // 在非开发环境中，使用HTTP严格安全传输(or HSTS) 对于保护web安全是非常重要的。
                // 强制实施 HTTPS 在 ASP.NET Core，配合 app.UseHttpsRedirection
                //app.UseHsts();
            }
            #endregion

            #region Swagger

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                //根据版本名称倒序 遍历展示
                typeof(ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version => {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{ConstString.AppName} {version}");//{ConstString.AppName} 
                });

                //注入汉化脚本
                //c.InjectOnCompleteJavaScript($"/swagger_translator.js");

                //c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("index.html");
                c.RoutePrefix = "";
            });
            #endregion

            #region CORS

            app.UseCors("LimitRequests");

            #endregion

            // 使用静态文件
            app.UseStaticFiles();
            // 使用cookie
            app.UseCookiePolicy();
            // 返回错误码
            app.UseStatusCodePages();//把错误码返回前台，比如是404

            app.UseMvc();
        }

        private static Type[] GetAssemblyTypes(Type interfaceType)
        {
            return ( from assembly in AppDomain.CurrentDomain.GetAssemblies()
                     from type in assembly.GetTypes()
                     where interfaceType.IsAssignableFrom(type) && type.IsClass
                                                                && !type.IsAbstract && !type.IsAutoClass
                     select type ).ToArray();
        }

        private static Type[] GetAssemblyTypes(Assembly assembly, Type interfaceType)
        {
            return ( from type in assembly.GetTypes()
                     where interfaceType.IsAssignableFrom(type) && type.IsClass
                                                                && !type.IsAbstract && !type.IsAutoClass
                     select type ).ToArray();
        }
    }
}
