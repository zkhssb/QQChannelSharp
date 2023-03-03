using QQChannelSharp.Dto.Members;
using QQChannelSharp.Enumerations;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 频道成员事件
    /// </summary>
    public class GuildMemberEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 状态类型
        /// <br/>
        /// 不存在 Create
        /// </summary>
        public required StateChangeType Type { get; init; }

        /// <summary>
        /// 事件完整类型 (如只是简单判断建议使用<see cref="Type"/>)
        /// </summary>
        public required EventType EventType { get; init; }

        /// <summary>
        /// 触发事件的成员
        /// </summary>
        public required Member Member { get; init; }
    }
}