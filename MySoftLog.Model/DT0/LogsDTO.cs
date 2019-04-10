using System;
using System.Collections.Generic;
using System.Text;

namespace MySoftLog.Model.DT0
{
    /// <summary>
    /// 批量日志
    /// </summary>
    [Serializable]
    public class LogsDTO
    {
        /// <summary>
        /// 日志数据
        /// </summary>
        public List<LogDTO> Logs { get; set; }
    }
}
