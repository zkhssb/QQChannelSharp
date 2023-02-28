using System.Text.Json.Serialization;

namespace QQChannelSharp.Enumerations
{
    public enum MessagePagerType
    {
        /// <summary>
        /// 拉取消息ID上下的消息
        /// </summary>
        [JsonPropertyName("around")]
        Around = 0,
        /// <summary>
        /// 拉取消息ID之前的消息
        /// </summary>
        [JsonPropertyName("before")]
        Before = 1,
        /// <summary>
        /// 拉取消息ID之后的消息
        /// </summary>
        [JsonPropertyName("after")]
        After = 2
    }
}
