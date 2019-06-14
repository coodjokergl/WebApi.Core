using System;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.Platform.Swagger;

namespace WebApi.Core.Service.Controllers.V1
{
    /// <summary>
    /// api 测试接口
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [CustomRoute(ApiVersions.V1)]
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
            return $@"接口：V1 用户: {user} 密码： {pass} 服务器时间： {DateTime.Now}";
        }


        /// <summary>
        /// 测试POST方法
        /// </summary>
        /// <param name="userData">用户密码</param>
        /// <returns></returns>
        [HttpPost]
        public string TestPost(UserData userData)
        {
            return $@"POST 接口：V1 用户: {userData.User} 密码： {userData.Pass} 服务器时间： {DateTime.Now}";
        }
    }

    /// <summary>
    /// 用户数据
    /// </summary>
    [Serializable]
    public class UserData
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Pass { get; set; }
    }
}
