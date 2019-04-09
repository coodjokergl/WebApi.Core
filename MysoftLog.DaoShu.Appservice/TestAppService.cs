using System;
using MySoftLog.IService.DaoShu;

namespace MysoftLog.DaoShu.Appservice
{
    /// <summary>
    /// 测试服务
    /// </summary>
    public class TestAppService : ITest
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
