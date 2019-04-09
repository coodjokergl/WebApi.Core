using System;
using System.Collections.Generic;
using System.Text;
using MySoftLog.Model.DT0;

namespace MySoftLog.IService.DaoShu
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDaoShu :IServiceBase
    {
        /// <summary>
        /// 查询客户信息
        /// </summary>
        /// <returns></returns>
        List<CustomerInfoDTO> SearchCustomerInfo();
    }
}
