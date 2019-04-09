using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Core.Activators.Reflection;
using Microsoft.AspNetCore.Mvc;
using MySoftLog.Core.SwaggerHelper;
using MySoftLog.IService;

namespace MySoftLog.Core.Controllers.V2
{
    /// <summary>
    /// api 测试接口
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [CustomRoute(ApiVersions.V2)]
    public class TestController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="te"></param>
        public TestController(ITest te)
        {
            TestService = te;
        }

        /// <summary>
        /// 服务
        /// </summary>
        public ITest TestService { get; set; }

        /// <summary>
        /// 测试方法
        /// </summary>
        /// <param name="user">用户名称</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Test")]
        public string Test(string user,string pass)
        {
            return $@"接口：V2 用户: {user} 密码： {pass} 服务器时间： {TestService.Test()}";
        }
    }
}
