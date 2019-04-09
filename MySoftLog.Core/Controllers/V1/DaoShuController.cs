using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Core.Activators.Reflection;
using Microsoft.AspNetCore.Mvc;
using MySoftLog.Core.SwaggerHelper;
using MySoftLog.IService.DaoShu;

namespace MySoftLog.Core.Controllers.V1
{
    /// <summary>
    /// 导数工具日志控制器
    /// </summary>
    [Produces("application/json")]
    //[ApiController]
    //[CustomRoute(ApiVersions.V1)]
    [Route("api/DaoShu")]
    public class DaoShuController : Controller
    {
        /// <summary>
        /// 服务
        /// </summary>
        public ITest TestService { get; set; }

        /// <summary>
        /// 测试方法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Test")]
        public string Test()
        {
            return $@"用户: 1 密码： 2 服务器时间： {TestService.Test()}";
        }
    }
}
