using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Core.Platform.Dto;
using WebApi.Core.Platform.Log;

namespace WebApi.Core.Platform.Filter
{
    /// <summary>
    /// 全局异常错误日志
    /// </summary>
    public class ActionFilter : IActionFilter
    {
        private readonly IHostingEnvironment _env;
        private readonly ILogHelper _loggerHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        /// <param name="loggerHelper"></param>
        public ActionFilter(IHostingEnvironment env, ILogHelper loggerHelper)
        {
            _env = env;
            _loggerHelper = loggerHelper;
        }

        /// <summary>
        /// 执行完成后
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        /// <summary>
        /// 执行中
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
