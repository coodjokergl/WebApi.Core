using System;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.Platform.Swagger;

namespace WebApi.Core.Service.Controllers.V2
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
        public TestController()
        {
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        /// <param name="user">用户名称</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Test")]
        public string Test(string user, string pass)
        {
            return $@"接口：V2 用户: {user} 密码： {pass} 服务器时间： {DateTime.Now}";
        }
    }
}
