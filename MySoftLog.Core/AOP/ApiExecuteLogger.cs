using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using MySoftLog.Core.Log;

namespace MySoftLog.Core.AOP
{
    /// <summary>
    /// Api 执行日志记录
    /// </summary>
    public class ApiExecuteLogger :IInterceptor
    {
        private ILogHelper LogHelper { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logHelper"></param>
        public ApiExecuteLogger(ILogHelper logHelper)
        {
            LogHelper = logHelper;
        }

        /// <summary>
        /// 拦截器
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            try
            {
                //记录操作日志
                LogHelper.ExecuteApi(invocation);
            }
            catch
            {
                //屏蔽日志异常
            }

            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                LogHelper.Debug(invocation,exception);
                throw;
            }
        }
    }
}
