using System;
using System.Collections.Generic;
using System.Text;
using MySoftLog.Model.DT0;

namespace MySoftLog.IService.DaoShu
{
    /// <summary>
    /// 导数日志记录
    /// </summary>
    public interface IDaoShuLog :IServiceBase
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="log">日志数据</param>
        /// <returns></returns>
        void AddLog(LogDTO log);

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logs">日志数据</param>
        /// <returns></returns>
        void AddLogs(LogsDTO logs);

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <returns>日志清单</returns>
        List<LogDTO> ListLog();

        /// <summary>
        /// 清理日志
        /// </summary>
        void ClearLog();
    }
}
