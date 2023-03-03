using QQChannelSharp.Dto.Message;

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
    }
}