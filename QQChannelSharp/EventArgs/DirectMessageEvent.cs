using QQChannelSharp.Dto.Message;

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
    }
}