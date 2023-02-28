using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Roles
{
    /// <summary>
    /// UpdateResult 创建，删除等行为的返回
    /// </summary>
    public class UpdateResult
    {
        [JsonPropertyName("guild_id")]
        public required string GuildID { get; set; }

        [JsonPropertyName("role")]
        public required Role Role { get; set; }
    }
}
