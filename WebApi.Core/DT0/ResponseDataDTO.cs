using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WebApi.Core.DT0
{
    /// <summary>
    /// API接口返回值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseDataDTO<T>
    {
        /// <summary>
        /// 返回编码 1000 成功 0 失败
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }
    }

    /// <summary>
    /// 返回码
    /// </summary>
    public static class ResponseHelper
    {
        /// <summary>
        /// 成功
        /// </summary>
        public static readonly int SuccessCode = 1000;

        /// <summary>
        /// 失败
        /// </summary>
        public static readonly int ErrorCode = 0;

        /// <summary>
        /// 生成成功数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResponseDataDTO<T> ToSuccessResponse<T>(this T data)
        {
            return new ResponseDataDTO<T>()
            {
                Code = SuccessCode,
                Msg = "success",
                Data = data
            };
        }

        /// <summary>
        /// 生成成功数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResponseDataDTO<IEnumerable<T>> ToSuccessResponse<T>(this IEnumerable<T> data) where T : DtoBase
        {
            return new ResponseDataDTO<IEnumerable<T>>()
            {
                Code = SuccessCode,
                Msg = "success",
                Data = data
            };
        }

        /// <summary>
        /// 生成成功数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResponseDataDTO<DtoBase> CreateErrorResponse(this string data)
        {
            return new ResponseDataDTO<DtoBase>()
            {
                Code = ErrorCode,
                Msg = data,
                Data = null
            };
        }
    }
}
