using System.Runtime.Serialization;

namespace QQChannelSharp.Enumerations
{
    /// <summary>
    /// 表情表态对象类型
    /// </summary>
    public enum ReactionTargetType
    {
        /// <summary>
        /// 消息
        /// </summary>
        [EnumMember(Value = "ReactionTargetType_MSG")]
        Msg = 0,
        /// <summary>
        /// 帖子
        /// </summary>
        [EnumMember(Value = "ReactionTargetType_FEED")]
        Feed = 1,
        /// <summary>
        /// 评论
        /// </summary>
        [EnumMember(Value = "ReactionTargetType_COMMNENT")] // 有错字, 应该是 ReactionTargetType_COMMENT
        Comment = 2,
        /// <summary>
        /// 回复
        /// </summary>
        [EnumMember(Value = "ReactionTargetType_REPLY")]
        Reply = 3,
    }
}
