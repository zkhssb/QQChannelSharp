using QQChannelSharp.Enumerations;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 主题帖子事件 (帖子=主题的回复)
    /// </summary>
    public class PostEvent : BaseChannelEventArgs
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
        /// 帖子信息
        /// </summary>
        public required Dto.Forum.Post Post { get; init; }
    }
}