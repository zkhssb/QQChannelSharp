using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Message
{
    /// <summary>
    /// MessageReaction 表情表态动作
    /// </summary>
    public class MessageReaction
    {
        [JsonPropertyName("user_id")]
        public required string UserID { get; set; }

        [JsonPropertyName("channel_id")]
        public required string ChannelID { get; set; }

        [JsonPropertyName("guild_id")]
        public required string GuildID { get; set; }

        [JsonPropertyName("target")]
        public required ReactionTarget Target { get; set; }

        [JsonPropertyName("emoji")]
        public required Emoji Emoji { get; set; }
    }
}
