using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.ApiPermissions
{
    /// <summary>
    /// APIPermissionDemandToCreate 创建频道 API 接口权限授权链接结构体定义
    /// </summary>
    public class APIPermissionDemandToCreate
    {
        /// <summary>
        /// 子频道 ID
        /// </summary>
        [JsonPropertyName("channel_id")]
        public required string ChannelID { get; set; }

        /// <summary>
        /// 接口权限链接中的接口权限描述信息
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("api_identify")]
        public APIPermissionDemandIdentify? APIIdentify { get; set; }

        /// <summary>
        /// 接口权限链接中的机器人可使用功能的描述信息
        /// </summary>
        [JsonPropertyName("desc")]
        public required string Desc { get; set; }
    }
}
