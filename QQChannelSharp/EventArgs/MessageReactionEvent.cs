using QQChannelSharp.Dto.Message;
using QQChannelSharp.Enumerations;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 表情表态事件
    /// </summary>
    public class MessageReactionEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 表情表态事件状态
        /// 不存在 Update 和 Create
        /// </summary>
        public StateChangeType Type { get; init; }

        /// <summary>
        /// 事件完整类型 (如只是简单判断建议使用<see cref="Type"/>)
        /// </summary>
        public required EventType EventType { get; init; }

        /// <summary>
        /// 表情表态操作
        /// </summary>
        public required MessageReaction Reaction { get; init; }
    }
}