using QQChannelSharp.Dto.Message;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 公域机器人消息撤回事件
    /// </summary>
    public class PublicMessageDeleteEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 删除的消息信息
        /// </summary>
        public required MessageDelete MessageDelete { get; init; }
    }
}