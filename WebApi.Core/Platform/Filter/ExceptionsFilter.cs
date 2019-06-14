using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Core.Platform.Log;

namespace WebApi.Core.Platform.Filter
{
    /// <summary>
    /// 异常错误日志
    /// </summary>
    public class ExceptionsFilter : IExceptionFilter, Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter
    {
        private readonly IHostingEnvironment _env;
        private readonly ILogHelper _loggerHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        /// <param name="loggerHelper"></param>
        public ExceptionsFilter(IHostingEnvironment env, ILogHelper loggerHelper)
        {
            _env = env;
            _loggerHelper = loggerHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            LogException(context);
        }

        private void LogException(ExceptionContext context)
        {
            if (!context.ExceptionHandled) return;

            var json = new JsonErrorResponse();

            json.Message = context.Exception.Message;//错误信息
            if (_env.IsDevelopment())
            {
                json.DevelopmentMessage = context.Exception.StackTrace;//堆栈信息
            }
            context.Result = new InternalServerErrorObjectResult(json);
            _loggerHelper.Error(json.Message, WriteLog(json.Message, context.Exception));
            context.ExceptionHandled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            return Task.Run(() => {
                LogException(context);
            });         
        }

        /// <summary>
        /// 自定义返回格式
        /// </summary>
        /// <param name="throwMsg"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public string WriteLog(string throwMsg, Exception ex)
        {
            return string.Format("【自定义错误】：{0} \r\n【异常类型】：{1} \r\n【异常信息】：{2} \r\n【堆栈调用】：{3}", new object[] { throwMsg,
                ex.GetType().Name, ex.Message, ex.StackTrace });
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class InternalServerErrorObjectResult : ObjectResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public InternalServerErrorObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }

    /// <summary>
    /// 返回错误信息
    /// </summary>
    [Serializable]
    public class JsonErrorResponse
    {
        /// <summary>
        /// 生产环境的消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 开发环境的消息
        /// </summary>
        public string DevelopmentMessage { get; set; }
    }
}
