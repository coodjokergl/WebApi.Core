using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Core.Activators.Reflection;
using Microsoft.AspNetCore.Mvc;
using MySoftLog.Core.SwaggerHelper;
using MySoftLog.IService;
using MySoftLog.IService.DaoShu;
using MySoftLog.Model.DT0;

namespace MySoftLog.Core.Controllers
{
    /// <summary>
    /// 导数工具日志控制器
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [CustomRouteAttribute]
    public class DaoShuController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="daoShu"></param>
        public DaoShuController(IDaoShu daoShu)
        {
            DaoShu = daoShu;
        }

        /// <summary>
        /// 服务
        /// </summary>
        public IDaoShu DaoShu { get; set; }

       /// <summary>
       /// 测试方法
       /// </summary>
       /// <param name="start">起始页序号</param>
       /// <param name="end">结束页序号</param>
       /// <returns></returns>
        [HttpGet]
        //[Route("SearchCustomerInfo")]
        public List<CustomerInfoDTO>  SearchCustomerInfo(int start,int end)
        {
            return DaoShu.SearchCustomerInfo().Skip(start).Take(end - start).ToList();
        }
    }
}
