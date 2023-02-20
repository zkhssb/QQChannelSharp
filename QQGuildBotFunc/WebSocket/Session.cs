using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQGuildBotFunc.WebSocket
{
    /// <summary>
    /// Session 连接的 session 结构，包括链接的所有必要字段
    /// </summary>
    public class Session
    {
        public required Guid Guid { get; init; }
        public required ShardConfig Shard { get; set; }
        public required string Id { get; set; }
        public required string Url { get; set; }
        public required GuildBotInfo BotInfo { get; set; }
        public required int Intent { get; set; }
        public required long LastSeq { get; set; }
    }
}
