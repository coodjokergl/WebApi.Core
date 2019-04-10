using System;
using System.Collections.Generic;
using System.Text;
using MySoftLog.Model.DT0;
using Newtonsoft.Json;

namespace MySoftLog.Model
{
    /// <summary>
    /// 页面查询数据基类
    /// </summary>
    [Serializable]
    public class PageInfoDTO<T> :DTOBase where T : PageSearchParamsBaseDTO
    {
        /// <summary>
        /// 页面信息
        /// </summary>
        [JsonProperty("pageInfo")]
        public T PageInfo { get; set; }
        
    }

    /// <summary>
    /// 查询参数基类
    /// </summary>
    [Serializable]
    public class PageSearchParamsBaseDTO:DTOBase
    {
        /// <summary>
        /// 页序号
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 数据数量
        /// </summary>
        public int PageSize { get;set; }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        /// 是否降序排序
        /// </summary>
        public bool IsDesc { get; set; }
    }
}
