using System;
using MySoftLog.IService.DaoShu;

namespace MysoftLog.DaoShu.Appservice
{
    public class TestAppService : ITest
    {
        public string Test()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms");
        }
    }
}
