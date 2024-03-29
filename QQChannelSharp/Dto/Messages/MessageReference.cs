﻿using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Messages
{
    /// <summary>
    /// MessageReference 引用消息
    /// </summary>
    public class MessageReference
    {
        /// <summary>
        /// 消息 id
        /// </summary>
        [JsonPropertyName("message_id")]
        public required string MessageID { get; set; }

        /// <summary>
        /// 是否忽律获取消息失败错误
        /// </summary>
        [JsonPropertyName("ignore_get_message_error")]
        public bool IgnoreGetMessageError { get; set; }
    }
}
