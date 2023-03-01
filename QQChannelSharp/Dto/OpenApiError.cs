using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto
{
    public class OpenApiError
    {
        /// <summary>
        /// 错误描述
        /// </summary>
        [JsonPropertyName("message")]
        public required string Message { get; set; }
        /// <summary>
        /// 错误代码
        /// <br/>
        /// OpenApi错误代码: <see href="https://bot.q.qq.com/wiki/develop/api/openapi/error/error.html#code"/>
        /// </summary>
        [JsonPropertyName("code")]
        public required int ErrorCode { get; set; }
    }
}
