using QQChannelSharp.Dto.WebSocket;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 机器人鉴权成功事件
    /// </summary>
    public class ReadyEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 鉴权成功数据
        /// </summary>
        public required WSReadyData ReadyData { get; init; }
    }
}