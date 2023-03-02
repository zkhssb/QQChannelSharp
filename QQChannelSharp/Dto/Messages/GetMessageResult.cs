using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Messages
{
    public class GetMessageResult
    {
        [JsonPropertyName("message")]
        public required Message.Message Message { get; set; }
    }
}