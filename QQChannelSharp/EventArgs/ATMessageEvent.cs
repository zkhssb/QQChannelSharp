using QQChannelSharp.Dto.Message;
using QQChannelSharp.Entities;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// @消息事件
    /// </summary>
    public class ATMessageEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 消息数据
        /// </summary>
        public required Message Message { get; init; }

        /// <summary>
        /// 简单消息内容
        /// </summary>
        public required MessageContext Context { get; init; }
    }
}