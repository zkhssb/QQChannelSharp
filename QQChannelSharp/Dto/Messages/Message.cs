using QQChannelSharp.Dto.Members;
using QQChannelSharp.Dto.MessageArks;
using QQChannelSharp.Dto.Messages;
using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Message
{
    /// <summary>
    /// Message 消息结构体定义
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [JsonPropertyName("id")]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// 子频道ID
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelID { get; set; } = string.Empty;

        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("guild_id")]
        public string GuildID { get; set; } = string.Empty;

        /// <summary>
        /// 内容
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// 发送时间
        /// </summary>
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.MinValue;

        /// <summary>
        /// 消息编辑时间
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("edited_timestamp")]
        public DateTime? EditedTimestamp { get; set; }

        /// <summary>
        /// 是否@all
        /// </summary>
        [JsonPropertyName("mention_everyone")]
        public bool MentionEveryone { get; set; } = false;

        /// <summary>
        /// 消息发送方
        /// 当消息返回时为Null,接收消息时不为NULL
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("author")]
        public User? Author { get; set; }

        /// <summary>
        /// 消息发送方Author的member属性，只是部分属性
        /// 当消息返回时为Null,接收消息时不为NULL
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("member")]
        public Member? Member { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("attachments")]
        public MessageAttachment[]? Attachments { get; set; }

        /// <summary>
        /// 结构化消息-embeds
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("embeds")]
        public Embed[]? Embeds { get; set; }

        /// <summary>
        /// 消息中的提醒信息(@)列表
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("mentions")]
        public User[]? Mentions { get; set; }

        /// <summary>
        /// ark 消息
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("ark")]
        public Ark? Ark { get; set; }

        /// <summary>
        /// 私信消息
        /// </summary>
        [JsonPropertyName("direct_message")]
        public bool DirectMessage { get; set; }

        /// <summary>
        /// 子频道 seq，用于消息间的排序，seq 在同一子频道中按从先到后的顺序递增，不同的子频道之前消息无法排序
        /// </summary>
        [JsonPropertyName("seq_in_channel")]
        public string SeqInChannel { get; set; } = string.Empty;

        /// <summary>
        /// 引用的消息
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("message_reference")]
        public MessageReference? MessageReference { get; set; }

        /// <summary>
        /// 私信场景下，该字段用来标识从哪个频道发起的私信
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("src_guild_id")]
        public string? SrcGuildID { get; set; }
    }
}
