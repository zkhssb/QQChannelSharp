using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.MessageArks
{
    /// <summary>
    /// MessageArk ark模板消息
    /// </summary>
    public class MessageArk
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("ark")]
        public Ark? Ark { get; set; }
    }
}
