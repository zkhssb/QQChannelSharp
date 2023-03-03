using QQChannelSharp.Dto.WebSocket;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 机器人重连成功事件
    /// </summary>
    public class ResumedEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 重连成功事件数据
        /// </summary>
        public required WSResumeData ResumeData { get; init; }
    }
}