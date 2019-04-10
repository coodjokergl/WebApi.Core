using System;
using System.Collections.Generic;
using System.Text;

namespace MySoftLog.Model.DT0.eChart
{
    /// <summary>
    /// 柱状图数据
    /// </summary>
    [Serializable]
    public class HistogramDTO :DTOBase
    {
        /// <summary>
        /// 版本信息
        /// </summary>
        public List<ColumnDTO> Columns { get; set; }

        /// <summary>
        /// 维度
        /// </summary>
        public List<string> Dimension { get; set; }
    }

    /// <summary>
    /// 柱子
    /// </summary>
    [Serializable]
    public class ColumnDTO:DTOBase{

        /// <summary>
        /// 维度
        /// </summary>
        public string Dimension { get;set; }

        /// <summary>
        /// 版本数据
        /// </summary>
        public List<DataItem> Data { get; set; }
    }
}
