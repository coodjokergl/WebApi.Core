using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Core.Platform.Entity
{
    /// <summary>
    /// 实体数据基类
    /// </summary>
    [Serializable]
    public abstract class EntityBase
    {
        /// <summary>
        /// 逐渐
        /// </summary>
        [Column("id")]
        public Guid Id { get; set; }
    }
}
