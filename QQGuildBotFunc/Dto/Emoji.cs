
using System.Text.Json.Serialization;

namespace QQGuildBotFunc.Dto
{
    /// <summary>
    /// Emoji 表情
    /// </summary>
    public class Emoji
    {
        [JsonPropertyName("id")]
        public required string ID { get; set; }
        [JsonPropertyName("type")]
        public required int Type { get; set; }
    }
}
