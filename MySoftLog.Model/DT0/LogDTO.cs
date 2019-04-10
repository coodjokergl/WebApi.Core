using System;
using System.Collections.Generic;
using System.Text;

namespace MySoftLog.Model.DT0
{
    /// <summary>
    /// 日志数据
    /// </summary>
    [Serializable]
    public class LogDTO :DTOBase
    {
        /// <summary>
        /// 日志主键
        /// </summary>
        public Guid LogId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get;set; }

        /// <summary>
        /// 日志时间
        /// </summary>
        public DateTime LogTime { get; set; }

        /// <summary>
        /// 扩展信息
        /// </summary>
        public Dictionary<string,object> ExtendData { get;set; }
    }
}
