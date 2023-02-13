using System.Text.Json.Serialization;

namespace QQGuildBotFunc.Dto.ApiPermissions
{
    /// <summary>
    /// APIPermissionDemand 接口权限需求对象
    /// </summary>
    public class APIPermissionDemand
    {
        /// <summary>
        /// 频道 ID
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("guild_id")]
        public string? GuildID { get; set; }

        /// <summary>
        /// 子频道 ID
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("channel_id")]
        public string? ChannelID { get; set; }

        /// <summary>
        /// 权限接口唯一标识
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("api_identify")]
        public APIPermissionDemandIdentify? APIIdentify { get; set; }

        /// <summary>
        /// 接口权限链接中的接口权限描述信息
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// 接口权限链接中的机器人可使用功能的描述信息
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("desc")]
        public string? Desc { get; set; }
    }
}
