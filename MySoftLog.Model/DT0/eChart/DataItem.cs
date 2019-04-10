using System;
using System.Collections.Generic;
using System.Text;

namespace MySoftLog.Model.DT0.eChart
{
    /// <summary>
    /// 数据项
    /// </summary>
    [Serializable]
    public class DataItem :DTOBase
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }
}
