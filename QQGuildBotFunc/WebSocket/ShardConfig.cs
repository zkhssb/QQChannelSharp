using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQGuildBotFunc.WebSocket
{
    /// <summary>
    /// ShardConfig 连接的 shard 配置，ShardID 从 0 开始，ShardCount 最小为 1
    /// </summary>
    public class ShardConfig
    {
        public required int ShardID { get; set; }
        public int ShardCount { get; set; } = 1;
    }
}
