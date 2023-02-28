using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.ChannelPermissions
{
    /// <summary>
    /// ChannelPermissions 子频道权限
    /// </summary>
    public class Permissions
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("channel_id")]
        public string? ChannelID { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("user_id")]
        public string? UserID { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("permissions")]
        public string? ChannelPermissions { get; set; }
    }
}
