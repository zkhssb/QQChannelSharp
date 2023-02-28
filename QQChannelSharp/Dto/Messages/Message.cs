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
        public required string ID { get; set; }

        /// <summary>
        /// 子频道ID
        /// </summary>
        [JsonPropertyName("channel_id")]
        public required string ChannelID { get; set; }

        /// <summary>
        /// 频道ID
        /// </summary>
        [JsonPropertyName("guild_id")]
        public required string GuildID { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [JsonPropertyName("content")]
        public required string Content { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        [JsonPropertyName("timestamp")]
        public required DateTime Timestamp { get; set; }

        /// <summary>
        /// 消息编辑时间
        /// </summary>
        [JsonPropertyName("edited_timestamp")]
        public required DateTime EditedTimestamp { get; set; }

        /// <summary>
        /// 是否@all
        /// </summary>
        [JsonPropertyName("mention_everyone")]
        public required bool MentionEveryone { get; set; }

        /// <summary>
        /// 消息发送方
        /// </summary>
        [JsonPropertyName("author")]
        public required User Author { get; set; }

        /// <summary>
        /// 消息发送方Author的member属性，只是部分属性
        /// </summary>
        [JsonPropertyName("member")]
        public required Member Member { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        [JsonPropertyName("attachments")]
        public required MessageAttachment[] Attachments { get; set; }

        /// <summary>
        /// 结构化消息-embeds
        /// </summary>
        [JsonPropertyName("embeds")]
        public required Embed[] Embeds { get; set; }

        /// <summary>
        /// 消息中的提醒信息(@)列表
        /// </summary>
        [JsonPropertyName("mentions")]
        public required User[] Mentions { get; set; }

        /// <summary>
        /// ark 消息
        /// </summary>
        [JsonPropertyName("ark")]
        public required Ark Ark { get; set; }

        /// <summary>
        /// 私信消息
        /// </summary>
        [JsonPropertyName("direct_message")]
        public required bool DirectMessage { get; set; }

        /// <summary>
        /// 子频道 seq，用于消息间的排序，seq 在同一子频道中按从先到后的顺序递增，不同的子频道之前消息无法排序
        /// </summary>
        [JsonPropertyName("seq_in_channel")]
        public required string SeqInChannel { get; set; }

        /// <summary>
        /// 引用的消息
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("message_reference")]
        public MessageReference? MessageReference { get; set; }

        /// <summary>
        /// 私信场景下，该字段用来标识从哪个频道发起的私信
        /// </summary>
        [JsonPropertyName("src_guild_id")]
        public required string SrcGuildID { get; set; }
    }
}
