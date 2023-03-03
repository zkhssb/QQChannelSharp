using QQChannelSharp.Dto;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 机器人WebSocket错误通知事件
    /// </summary>
    public class ErrorNotifyEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// WS错误信息
        /// </summary>
        public required ErrorNotify Error { get; init; }
    }
}