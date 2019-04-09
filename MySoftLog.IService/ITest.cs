using System;
using System.Collections.Generic;
using System.Text;

namespace MySoftLog.IService
{
    /// <summary>
    /// 测试接口
    /// </summary>
    public interface ITest : IServiceBase
    {
        /// <summary>
        /// 测试接口
        /// </summary>
        /// <returns></returns>
        string Test();
    }
}
