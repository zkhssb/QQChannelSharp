using QQChannelSharp.Dto.Message;
using QQChannelSharp.Entities;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 私信消息事件
    /// </summary>
    public class DirectMessageEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 消息数据
        /// </summary>
        public required Message Message { get; init; }

        /// <summary>
        /// 简单消息内容
        /// </summary>
        public required DirectMessageContext Context { get; init; }
    }
}