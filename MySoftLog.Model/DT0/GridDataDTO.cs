using System;
using System.Collections.Generic;
using System.Text;
using MySoftLog.Model.DT0;
using Newtonsoft.Json;

namespace MySoftLog.Model
{
    /// <summary>
    /// 数据总数
    /// </summary>
    [Serializable]
    public class GridDataDTO<T>where T:DTOBase
    {
        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("list")]
        public List<T> List { get;set; }

        /// <summary>
        /// 页面信息
        /// </summary>
        [JsonProperty("pageInfo")]
        public GridInfo PageInfo { get; set; }
    }

    /// <summary>
    /// 网格信息
    /// </summary>
    [Serializable]
    public class GridInfo :PageSearchParamsBaseDTO
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }
    }
}
