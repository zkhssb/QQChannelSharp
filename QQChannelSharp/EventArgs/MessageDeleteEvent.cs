using QQChannelSharp.Dto.Message;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 频道消息撤回事件
    /// 该事件仅限<see langword="私域"/>机器人,如果你是公域机器人,请考虑使用<see cref="PublicMessageDeleteEvent"/>
    /// </summary>
    public class MessageDeleteEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 删除的消息信息
        /// </summary>
        public required MessageDelete MessageDelete { get; init; }
    }
}