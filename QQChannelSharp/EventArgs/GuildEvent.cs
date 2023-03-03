using QQChannelSharp.Dto;
using QQChannelSharp.Enumerations;

namespace QQChannelSharp.EventArgs
{
    /// <summary>
    /// 频道事件
    /// </summary>
    public class GuildEvent : BaseChannelEventArgs
    {
        /// <summary>
        /// 状态类型
        /// 为Create时表示机器人被加入频道
        /// <br/>
        /// 不存在 Add
        /// </summary>
        public required StateChangeType Type { get; init; }

        /// <summary>
        /// 事件完整类型 (如只是简单判断建议使用<see cref="Type"/>)
        /// </summary>
        public required EventType EventType { get; init; }

        /// <summary>
        /// 触发事件的类型
        /// </summary>
        public required Guild EventGuild { get; init; }
    }
}