using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using Autofac.Core.Activators.Reflection;
using AutoMapper;
using Castle.Components.DictionaryAdapter;
using Microsoft.AspNetCore.Mvc;
using MySoftLog.Core.SwaggerHelper;
using MySoftLog.IService;
using MySoftLog.IService.DaoShu;
using MySoftLog.Model;
using MySoftLog.Model.DT0;
using MySoftLog.Model.DT0.eChart;

namespace MySoftLog.Core.Controllers
{
    /// <summary>
    /// 导数工具日志查询接口
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [CustomRouteAttribute]
    public class DaoShuViewController : Controller
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="daoShu"></param>
        /// <param name="mapper"></param>
        public DaoShuViewController(IDaoShuView daoShu, IMapper mapper)
        {
            DaoShu = daoShu;
            Mapper = mapper;
        }

        /// <summary>
        /// 服务
        /// </summary>
        public IDaoShuView DaoShu { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IMapper Mapper { get; }
        #region 网格取数

        /// <summary>
        /// 异常监控信息
        /// </summary>
        /// <param name="info">查询条件</param>
        /// <returns>异常信息列表</returns>
        [HttpPost]
        public ResponseDataDTO<CustomerExceptionDataDTO> ListException(PageInfoDTO<ExceptionInfoDTO> info)
        {
            return ( DaoShu?.ListCustomerInfo(info) ?? new CustomerExceptionDataDTO()
            {
                List = new List<CustomerExceptionDataItemDTO>(),
                PageInfo = Mapper.Map<GridInfo>(info)
            } ).ToSuccessResponse();
        }

        /// <summary>
        /// 客户应用台账
        /// </summary>
        /// <param name="info">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        public ResponseDataDTO<DsCustomerUseInfo> ListUserInfo(PageInfoDTO<PageSearchParamsBaseDTO> info)
        {
            return ( DaoShu?.ListUserInfo(info) ?? new DsCustomerUseInfo()
            {
                List = new List<CustomerExceptionDataItemDTO>(),
                PageInfo = Mapper.Map<GridInfo>(info)
            } ).ToSuccessResponse();
        }

        #endregion

        #region 图标分析

        /// <summary>
        /// 查询运行版本分析
        /// </summary>
        /// <param name="appCode"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseDataDTO<HistogramDTO> ViewRuntimeVersion(string appCode)
        {
            return ( DaoShu?.ViewRuntimeVersion(appCode) ).ToSuccessResponse();
        }


        /// <summary>
        /// 查询运行版本分析
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseDataDTO<HistogramDTO> VersionDataRepair(string appCode)
        {
            return ( DaoShu?.ViewRuntimeVersion(appCode) ).ToSuccessResponse();
        }

        #endregion
    }
}
