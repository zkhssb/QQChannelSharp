using QQChannelSharp.Enumerations;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 论坛主题事件
    /// </summary>
    public class ThreadEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 状态类型
        /// <br/>
        /// 不存在 Add
        /// </summary>
        public required StateChangeType Type { get; init; }

        /// <summary>
        /// 事件完整类型 (如只是简单判断建议使用<see cref="Type"/>)
        /// </summary>
        public required EventType EventType { get; init; }

        /// <summary>
        /// 主题信息
        /// </summary>
        public required Dto.Forum.Thread Thread { get; init; }
    }
}