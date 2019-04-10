using System;
using System.Collections.Generic;

namespace MySoftLog.Model.DT0
{
    /// <summary>
    /// 异常监控信息
    /// </summary>
    [Serializable]
    public class CustomerExceptionDataDTO :GridDataDTO<CustomerExceptionDataItemDTO>
    {
       
    }

    /// <summary>
    /// 导数异常信息
    /// </summary>
    [Serializable]
    public class CustomerExceptionDataItemDTO :DTOBase 
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CstName { get; set; }

        /// <summary>
        /// 导数工具版本
        /// </summary>
        public string SoftVersion { get; set; }

        /// <summary>
        /// 导数类型
        /// </summary>
        public string ImportType { get; set; }

        /// <summary>
        /// 原系统版本
        /// </summary>
        public string SourceVersion { get;set; }

        /// <summary>
        /// 现系统版本
        /// </summary>
        public string TargetVersion { get;set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string ErrerMsg { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginDate { get;set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get;set; }

        /// <summary>
        /// 结果说明
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 批次操作主键
        /// </summary>
        public Guid Code { get; set; }
    }
}
