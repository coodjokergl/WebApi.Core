using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace MySoftLog.Core.AOP
{
    /// <summary>
    /// Api 监察器 做before after 插件使用
    /// </summary>
    public class ApiWatcher:IInterceptor
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public ApiWatcher()
        {

        }

        /// <summary>
        /// 拦截器
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            //存在 扩展 则执行扩展

            invocation.Proceed();//前后均不存在，直接执行

            //存在 扩展后 执行扩展后

        }
    }
}
