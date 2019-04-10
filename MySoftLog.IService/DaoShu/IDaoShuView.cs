using System;
using System.Collections.Generic;
using System.Text;
using MySoftLog.Model;
using MySoftLog.Model.DT0;
using MySoftLog.Model.DT0.eChart;

namespace MySoftLog.IService.DaoShu
{
    /// <summary>
    /// 导数视图
    /// </summary>
    public interface IDaoShuView :IServiceBase
    {
        /// <summary>
        /// 查询客户信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        CustomerExceptionDataDTO ListCustomerInfo(PageInfoDTO<ExceptionInfoDTO> info);


        /// <summary>
        /// 客户应用台账
        /// </summary>
        /// <param name="info">查询条件</param>
        /// <returns></returns>
        DsCustomerUseInfo ListUserInfo(PageInfoDTO<PageSearchParamsBaseDTO> info);

        /// <summary>
        /// 查询运行版本分析
        /// </summary>
        /// <param name="appCode"></param>
        /// <returns></returns>
        HistogramDTO ViewRuntimeVersion(string appCode);
        
    }
}
