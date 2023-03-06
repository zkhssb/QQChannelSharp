using QQChannelSharp.Dto.Keyboard;
using QQChannelSharp.Dto.Markdown;
using QQChannelSharp.Dto.MessageArks;
using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Messages
{
    /// <summary>
    /// 消息创建
    /// </summary>
    public class MessageToCreate
    {
        /// <summary>
        /// 文本消息内容
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("content")]
        public virtual string? Content { get; set; }

        /// <summary>
        /// 附件消息
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("embed")]
        public Embed? Embed { get; set; }

        /// <summary>
        /// ARK消息
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("ark")]
        public Ark? Ark { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("image")]
        public string? Image { get; set; }

        /// <summary>
        /// 要回复的消息id，为空是主动消息，公域机器人会异步审核，不为空是被动消息，公域机器人会校验语料
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("msg_id")]
        public string? MsgId { get; set; }

        /// <summary>
        /// 消息引用
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("message_reference")]
        public MessageReference? MessageReference { get; set; }

        /// <summary>
        /// Markdown消息
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("markdown")]
        public MarkdownMessage? Markdown { get; set; }

        /// <summary>
        /// 消息按钮组件
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("keyboard")]
        public MessageKeyboard? Keyboard { get; set; }

        /// <summary>
        /// 要回复的事件id, 逻辑同MsgID
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("event_id")]
        public string? EventId { get; set; }
    }
}
