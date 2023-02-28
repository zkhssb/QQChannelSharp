using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Messages
{
    /// <summary>
    /// MessageAttachment 附件定义
    /// </summary>
    public class MessageAttachment
    {
        [JsonPropertyName("url")]
        public required string URL { get; set; }
    }
}
