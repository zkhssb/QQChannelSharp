using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Roles
{
    /// <summary>
    /// UpdateRole role 更新请求承载
    /// </summary>
    public class UpdateRole
    {
        [JsonPropertyName("guild_id")]
        public required string GuildID { get; set; }

        [JsonPropertyName("filter")]
        public required UpdateRoleFilter Filter { get; set; }

        [JsonPropertyName("info")]
        public required Role Update { get; set; }
    }
}
