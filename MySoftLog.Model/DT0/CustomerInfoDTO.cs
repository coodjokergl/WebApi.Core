using System;
using System.Collections.Generic;
using System.Text;

namespace MySoftLog.Model.DT0
{
    /// <summary>
    /// 客户导数信息
    /// </summary>
    [Serializable]
    public class CustomerInfoDTO :DTOBase 
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CstName { get; set; }

        /// <summary>
        /// 导数工具版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 导数类型
        /// </summary>
        public string DaoShuType { get; set; }

        /// <summary>
        /// 原系统版本
        /// </summary>
        public string OldVer { get;set; }

        /// <summary>
        /// 现系统版本
        /// </summary>
        public string NewVer { get;set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string ErrerMsg { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime Date { get;set; }
    }
}
