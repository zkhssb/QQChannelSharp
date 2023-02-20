using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.ApiPermissions
{
    /// <summary>
    /// APIPermissionDemandIdentify  API 权限需求标识对象
    /// </summary>
    public class APIPermissionDemandIdentify
    {
        /// <summary>
        /// API 接口名，例如 /guilds/{guild_id}/members/{user_id}
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("path")]
        public string? Path { get; set; }

        /// <summary>
        /// 请求方法，例如 GET
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("method")]
        public string? Method { get; set; }
    }
}
