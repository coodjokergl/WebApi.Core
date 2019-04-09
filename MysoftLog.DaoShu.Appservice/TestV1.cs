using System;
using MySoftLog.IService;

namespace MysoftLog.DaoShu
{
    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestV1 : ITest
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        public string Test()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms");
        }
    }
}
