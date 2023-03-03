using QQChannelSharp.Enumerations;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 帖子回复事件 (帖子 = 主题的回复)
    /// </summary>
    public class ReplyEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 状态类型
        /// <br/>
        /// 不存在 Add Update
        /// </summary>
        public required StateChangeType Type { get; init; }

        /// <summary>
        /// 事件完整类型 (如只是简单判断建议使用<see cref="Type"/>)
        /// </summary>
        public required EventType EventType { get; init; }

        /// <summary>
        /// 回复信息
        /// </summary>
        public required Dto.Forum.Reply Reply { get; init; }
    }
}