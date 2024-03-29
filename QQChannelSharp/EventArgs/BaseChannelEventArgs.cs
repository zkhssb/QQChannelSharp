﻿using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.Interfaces;
using QQChannelSharp.WebSocket;

namespace QQChannelSharp.EventArgs
{
    public class BaseChannelEventArgs : System.EventArgs
    {
        /// <summary>
        /// 机器人会话信息
        /// </summary>
        public required Session Session { get; init; }

        /// <summary>
        /// 原始信息
        /// </summary>
        public required WebSocketPayload Payload { get; init; }

        /// <summary>
        /// 公开应用接口
        /// </summary>
        public required IOpenApi OpenApi { get; init; }
    }
}