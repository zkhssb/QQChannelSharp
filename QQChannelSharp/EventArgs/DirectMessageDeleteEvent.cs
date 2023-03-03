using QQChannelSharp.Dto.Message;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 私信消息撤回事件
    /// </summary>
    public class DirectMessageDeleteEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 删除的消息信息
        /// </summary>
        public required MessageDelete MessageDelete { get; init; }
    }
}