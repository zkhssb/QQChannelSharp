using QQChannelSharp.Dto.Interactions;
using QQChannelSharp.Enumerations;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 互动事件
    /// </summary>
    public class InteractionEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 状态类型
        /// <br/>
        /// 目前貌似只有互动创建 (Create)
        /// </summary>
        public required StateChangeType Type { get; init; }

        /// <summary>
        /// 事件完整类型 (如只是简单判断建议使用<see cref="Type"/>)
        /// </summary>
        public required EventType EventType { get; init; }
        /// <summary>
        /// 互动信息
        /// </summary>
        public required Interaction Interaction { get; init; }
    }
}