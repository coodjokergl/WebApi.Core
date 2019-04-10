using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySoftLog.IService.DaoShu;
using MySoftLog.Model.DT0;

namespace MysoftLog.DaoShu
{
    /// <summary>
    /// 导数结果
    /// </summary>
    public class DaoShuLog :IDaoShuLog
    {
        /// <summary>
        /// 日志
        /// </summary>
        public static List<LogDTO> Logs = new List<LogDTO>();

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="log">日志数据</param>
        /// <returns></returns>
        public void AddLog(LogDTO log)
        {
            if(log == null) return;
            lock (Logs)
            {
                 Logs.Add(log);
            }
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logs"></param>
        public void AddLogs(LogsDTO logs)
        {
            if(logs == null || logs.Logs == null || !logs.Logs.Any()) return;
            lock (Logs)
            {
                Logs.AddRange(logs.Logs);
            }
        }

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <returns>日志集合</returns>
        public List<LogDTO> ListLog()
        {
            lock (Logs)
            {
                return Logs;
            }
        }

        /// <summary>
        /// 清理日志
        /// </summary>
        public void ClearLog()
        {
            lock (Logs)
            {
                Logs.Clear();
            }
        }
    }
}
