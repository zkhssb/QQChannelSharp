using System.Text.Json.Serialization;

namespace QQGuildBotFunc.Dto.ApiPermissions
{
    /// <summary>
    /// APIPermission API 权限对象
    /// </summary>
    public class APIPermission
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

        /// <summary>
        /// API 接口名称，例如 获取频道信
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("desc")]
        public string? Desc { get; set; }

        /// <summary>
        /// 授权状态，auth_stats 为 1 时已授权
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("auth_status")]
        public int? AuthStatus { get; set; }
    }
}
