using System;

namespace MySoftLog.IRepository
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T:class ,new ()
    {
    }
}
