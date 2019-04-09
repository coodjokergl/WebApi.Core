using System;
using System.Collections.Generic;
using System.Text;
using MySoftLog.IService.DaoShu;
using MySoftLog.Model.DT0;

namespace MysoftLog.DaoShu
{
    /// <summary>
    /// 导数
    /// </summary>
    public class DaoShu:IDaoShu
    {
        /// <summary>
        /// 查询客户信息
        /// </summary>
        /// <returns></returns>
        public List<CustomerInfoDTO> SearchCustomerInfo()
        {
            var res = new List<CustomerInfoDTO>();
            for (int i = 0; i < 100; i++)
            {
                res.Add(new CustomerInfoDTO()
                {
                    CstName = i.ToString(),
                    Version = "2.0",
                    DaoShuType = "Excel",
                    OldVer = "1.0",
                    NewVer = "2.0",
                    ErrerMsg = "未将对象引用到实例",
                    Date = DateTime.Now.AddMinutes(-10 * i)
                });
            }
            return res;
        }
    }
}
