using QQChannelSharp.Dto.Audio;
using QQChannelSharp.Enumerations;

namespace QQChannelSharp.EventArgs
{
    public class AudioEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 音频事件类型
        /// </summary>
        public required AudioEventType Type { get; init; }

        /// <summary>
        /// 事件完整类型 (如只是简单判断建议使用<see cref="Type"/>)
        /// </summary>
        public required EventType EventType { get; init; }

        /// <summary>
        /// 音频操作
        /// </summary>
        public required AudioAction Action { get; init; }
    }
}