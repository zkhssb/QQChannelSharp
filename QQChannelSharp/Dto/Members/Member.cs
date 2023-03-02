using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Members
{
    /// <summary>
    /// Member 群成员
    /// </summary>
    public class Member
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("guild_id")]
        public string? GuildID { get; set; }

        [JsonPropertyName("joined_at")]
        public DateTime JoinedAt { get; set; } = DateTime.MinValue;

        [JsonPropertyName("nick")]
        public string Nick { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("user")]
        public User? User { get; set; }

        [JsonPropertyName("roles")]
        public string[] Roles { get; set; } = new string[0];

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("op_user_id")]
        public string? OpUserID { get; set; }
    }
}
