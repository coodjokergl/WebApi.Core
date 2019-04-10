using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MySoftLog.IService.DaoShu;
using MySoftLog.Model;
using MySoftLog.Model.DT0;
using MySoftLog.Model.DT0.eChart;

namespace MysoftLog.DaoShu
{
    /// <summary>
    /// 导数
    /// </summary>
    public class DaoShuView:IDaoShuView
    {
        /// <summary>
        /// 
        /// </summary>
        public  IMapper Mapper { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        public DaoShuView( IMapper mapper)
        {
            Mapper = mapper;
        }

        /// <summary>
        /// 异常监控信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public CustomerExceptionDataDTO ListCustomerInfo(PageInfoDTO<ExceptionInfoDTO> info)
        {
            var res = new CustomerExceptionDataDTO()
            {
                List = new List<CustomerExceptionDataItemDTO>(),
                PageInfo = Mapper.Map<GridInfo>(info.PageInfo)
            };
            res.PageInfo.Total = 1000 * info.PageInfo.PageSize;

            for (int i = info.PageInfo.PageSize * info.PageInfo.PageIndex; i < info.PageInfo.PageSize * (info.PageInfo.PageIndex + 1); i++)
            {
                res.List.Add(new CustomerExceptionDataItemDTO()
                {
                    CstName = i.ToString(),
                    SoftVersion = "2.0",
                    ImportType = "Excel",
                    SourceVersion = "1.0",
                    TargetVersion = "2.0",
                    ErrerMsg = "未将对象引用到实例",
                    BeginDate = DateTime.Now.AddMinutes(-10 * i),
                    Code = Guid.NewGuid()
                });
            }
            return res;
        }

        /// <summary>
        /// 客户应用台账
        /// </summary>
        /// <param name="info">查询条件</param>
        /// <returns></returns>
        public DsCustomerUseInfo ListUserInfo(PageInfoDTO<PageSearchParamsBaseDTO> info)
        {
            var res = new DsCustomerUseInfo()
            {
                List = new List<CustomerExceptionDataItemDTO>(),
                PageInfo = Mapper.Map<GridInfo>(info.PageInfo)
            };
            res.PageInfo.Total = 1000 * info.PageInfo.PageSize;

            for (int i = info.PageInfo.PageSize * info.PageInfo.PageIndex; i < info.PageInfo.PageSize * (info.PageInfo.PageIndex + 1); i++)
            {
                res.List.Add(new CustomerExceptionDataItemDTO()
                {
                    CstName = i.ToString(),
                    SoftVersion = "2.0",
                    ImportType = "Excel",
                    SourceVersion = "1.0",
                    TargetVersion = "2.0",
                    ErrerMsg = "未将对象引用到实例",
                    BeginDate = DateTime.Now.AddMinutes(-100 * i),
                    EndDate = DateTime.Now.AddMinutes(-10 * i),
                    Code = Guid.NewGuid()
                });
            }
            return res;
        }

        /// <summary>
        /// 查询运行版本分析
        /// </summary>
        /// <param name="appCode"></param>
        /// <returns></returns>
        public HistogramDTO ViewRuntimeVersion(string appCode)
        {
            return new HistogramDTO()
            {
                Dimension = new List<string>()
                {
                    "EXCEL导数","面对面导数"
                },
                Columns = new List<ColumnDTO>()
                {
                    new ColumnDTO()
                    {
                        Data = new List<DataItem>()
                        {
                            new DataItem()
                            {
                                Text = "EXCEL导数",
                                Value = "11"
                            },
                            new DataItem()
                            {
                                Text = "面对面导数",
                                Value = "33"
                            }
                        },Dimension = "SP5"
                    },
                    new ColumnDTO()
                    {
                        Data = new List<DataItem>()
                        {
                            new DataItem()
                            {
                                Text = "EXCEL导数",
                                Value = "44"
                            },
                            new DataItem()
                            {
                                Text = "面对面导数",
                                Value = "55"
                            }
                        },Dimension = "SP6"
                    },
                    new ColumnDTO()
                    {
                        Data = new List<DataItem>()
                        {
                            new DataItem()
                            {
                                Text = "EXCEL导数",
                                Value = "1234"
                            },
                            new DataItem()
                            {
                                Text = "面对面导数",
                                Value = "221"
                            }
                        },Dimension = "SP7"
                    },
                    new ColumnDTO()
                    {
                        Data = new List<DataItem>()
                        {
                            new DataItem()
                            {
                                Text = "EXCEL导数",
                                Value = "341"
                            },
                            new DataItem()
                            {
                                Text = "面对面导数",
                                Value = "1341"
                            }
                        },Dimension = "V2.0"
                    },
                }
            };

        }
    }
}
