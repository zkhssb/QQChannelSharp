﻿using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Message
{
    /// <summary>
    /// MessageDelete 消息删除结构体定义
    /// </summary>
    public class MessageDelete
    {
        /// <summary>
        /// 消息
        /// </summary>
        [JsonPropertyName("message")]
        public required Message Message { get; set; }

        /// <summary>
        /// 操作用户
        /// </summary>
        [JsonPropertyName("op_user")]
        public required User OpUser { get; set; }
    }
}
