using System;
using System.Collections.Generic;
using System.Text;

namespace MySoftLog.Model.DT0
{
    /// <summary>
    /// 异常信息查询
    /// </summary>
    [Serializable]
    public class ExceptionInfoDTO :PageSearchParamsBaseDTO
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
