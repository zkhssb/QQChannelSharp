using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Messages
{
    /// <summary>
    /// MessageEmbedThumbnail embed 消息的缩略图对象
    /// </summary>
    public class MessageEmbedThumbnail
    {
        [JsonPropertyName("url")]
        public required string URL { get; set; }
    }
}
