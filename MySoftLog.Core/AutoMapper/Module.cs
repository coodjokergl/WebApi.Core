using AutoMapper;
using MySoftLog.Model;

namespace MySoftLog.Core.AutoMapper
{
    /// <summary>
    /// 映射
    /// </summary>
    public class AutoModule :Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AutoModule()
        {
            CreateMap<PageSearchParamsBaseDTO, GridInfo>();
        }
    }
}
