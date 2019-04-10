using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac.Core.Activators.Reflection;
using Microsoft.AspNetCore.Mvc;
using MySoftLog.Core.SwaggerHelper;
using MySoftLog.IService;
using MySoftLog.IService.DaoShu;
using MySoftLog.Model;
using MySoftLog.Model.DT0;

namespace MySoftLog.Core.Controllers
{
    /// <summary>
    /// 导数工具日志管理接口
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [CustomRouteAttribute]
    public class DaoShuLogController : Controller
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="daoShu"></param>
        public DaoShuLogController(IDaoShuLog daoShu)
        {
            DaoShu = daoShu;
        }

        /// <summary>
        /// 服务
        /// </summary>
        public IDaoShuLog DaoShu { get; set; }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="log">日志数据</param>
        /// <returns></returns>
        [HttpPost]
        public void AddLog(LogDTO log)
        {
            DaoShu.AddLog(log);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logs">日志数据</param>
        /// <returns></returns>
        [HttpPost]
        public void AddLogs(LogsDTO logs)
        {
            DaoShu.AddLogs(logs);
        }

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <returns>日志集合</returns>
        [HttpGet]
        public ResponseDataDTO<List<LogDTO>> ListLog()
        {
            return DaoShu.ListLog().ToSuccessResponse();
        }

        /// <summary>
        /// 清理日志
        /// </summary>
        [HttpGet]
        public void ClearLog()
        {
            DaoShu.ClearLog();
        }
    }
}
