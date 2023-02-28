using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Messages
{
    /// <summary>
    /// MessageReactionUsers 消息表情表态用户列表
    /// </summary>
    public class MessageReactionUsers
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("users")]
        public User[]? Users { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("cookie")]
        public string? Cookie { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("is_end")]
        public bool? IsEnd { get; set; }
    }
}
