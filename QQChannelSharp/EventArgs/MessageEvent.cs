using QQChannelSharp.Dto.Message;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 频道消息创建事件
    /// <br/>
    /// 该事件仅限<see langword="私域"/>机器人,如果你是公域机器人,请考虑使用<see cref="ATMessageEvent"/>
    /// </summary>
    public class MessageEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 消息数据
        /// </summary>
        public required Message Message { get; init; }
    }
}