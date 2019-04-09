using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace MySoftLog.Core.AppSettings
{
    /// <summary>
    /// 程序配置操作类
    /// </summary>
    public class AppSettings
    {
        static IConfiguration Configuration { get; set; }
        static AppSettings()
        {
            Configuration = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource { Path = @"appsettings.json", ReloadOnChange = true })
                .Build();
            Configuration.GetChildren();
        }
        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static string App(params string[] sections)
        {
            try
            {
                var val = sections.Aggregate(string.Empty, (current, t) => current + (t + ":")).TrimEnd(':');
                return Configuration[val];
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static string[] Apps(params string[] sections)
        {
            try
            {
                var val = sections.Aggregate(string.Empty, (current, t) => current + (t + ":")).TrimEnd(':');
                return (Configuration[val]??string.Empty).Split(";");
            }
            catch (Exception)
            {
                return new string[0];
            }
        }
    }
}
