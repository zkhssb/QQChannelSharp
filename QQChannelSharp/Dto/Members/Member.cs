using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Members
{
    /// <summary>
    /// Member 群成员
    /// </summary>
    public class Member
    {
        [JsonPropertyName("guild_id")]
        public required string GuildID { get; set; }

        [JsonPropertyName("joined_at")]
        public required DateTime JoinedAt { get; set; }

        [JsonPropertyName("nick")]
        public required string Nick { get; set; }

        [JsonPropertyName("user")]
        public required User User { get; set; }

        [JsonPropertyName("roles")]
        public required string[] Roles { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("op_user_id")]
        public string? OpUserID { get; set; }
    }
}
