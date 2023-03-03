using QQChannelSharp.Dto.Channels;
using QQChannelSharp.Enumerations;

namespace QQChannelSharp.EventArgs
{
    public class ChannelEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 状态类型
        /// </summary>
        public required StateChangeType Type { get; init; }

        /// <summary>
        /// 事件完整类型 (如只是简单判断建议使用<see cref="Type"/>)
        /// </summary>
        public required EventType EventType { get; init; }

        /// <summary>
        /// 频道信息
        /// <br/>
        /// 状态更变后的频道信息
        /// </summary>
        public required Channel Channel { get; init; }
    }
}