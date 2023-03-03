namespace QQChannelSharp.Enumerations
{
    /// <summary>
    /// 状态变化类型
    /// </summary>
    public enum StateChangeType
    {
        /// <summary>
        /// 无状态或不确定状态,需要使用EventType或Payload.EventType来判断类型
        /// </summary>
        None,
        /// <summary>
        /// 加入、成员加入、表情表态添加
        /// </summary>
        Add,
        /// <summary>
        /// 创建、开始、被添加到频道
        /// </summary>
        Create,
        /// <summary>
        /// 删除、退出、解散事件
        /// </summary>
        Delete,
        /// <summary>
        /// 信息更新
        /// </summary>
        Update
    }

    /// <summary>
    /// 消息审核类型
    /// </summary>
    public enum MessageAuditType
    {
        /// <summary>
        /// 通过
        /// </summary>
        Pass,

        /// <summary>
        /// 不通过
        /// </summary>
        Reject
    }

    /// <summary>
    /// 音频事件类型
    /// </summary>
    public enum AudioEventType
    {
        /// <summary>
        /// 音频开始播放
        /// </summary>
        Start,
        /// <summary>
        /// 音频结束
        /// </summary>
        Finish,
        /// <summary>
        /// 机器人上麦
        /// </summary>
        OnMic,
        /// <summary>
        /// 机器人下麦
        /// </summary>
        OffMic,
    }

    /// <summary>
    /// 事件类型表 (只用于在Payload扩展 GetEventType 后判断类型)
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown,

        // 频道
        /// <summary>
        /// 机器人被加入频道
        /// </summary>
        GUILD_CREATE,
        /// <summary>
        /// 频道信息更新
        /// </summary>
        GUILD_UPDATE,
        /// <summary>
        /// 机器人被删除or频道解散
        /// </summary>
        GUILD_DELETE,

        // 子频道
        /// <summary>
        /// 子频道被创建
        /// </summary>
        CHANNEL_CREATE,
        /// <summary>
        /// 子频道信息更新
        /// </summary>
        CHANNEL_UPDATE,
        /// <summary>
        /// 子频道被删除
        /// </summary>
        CHANNEL_DELETE,

        // 成员
        /// <summary>
        /// 成员加入频道
        /// </summary>
        GUILD_MEMBER_ADD,
        /// <summary>
        /// 成员信息更新
        /// </summary>
        GUILD_MEMBER_UPDATE,
        /// <summary>
        /// 成员退出频道
        /// </summary>
        GUILD_MEMBER_REMOVE,

        /// <summary>
        /// 私域消息创建
        /// </summary>
        MESSAGE_CREATE,
        /// <summary>
        /// 消息表情表态添加
        /// </summary>
        MESSAGE_REACTION_ADD,
        /// <summary>
        /// 消息表情表态删除
        /// </summary>
        MESSAGE_REACTION_REMOVE,
        /// <summary>
        /// @消息
        /// </summary>
        AT_MESSAGE_CREATE,
        /// <summary>
        /// 公域消息撤回
        /// </summary>
        PUBLIC_MESSAGE_DELETE,
        /// <summary>
        /// 私信消息创建
        /// </summary>
        DIRECT_MESSAGE_CREATE,
        /// <summary>
        /// 私信被撤回
        /// </summary>
        DIRECT_MESSAGE_DELETE,

        // 音频
        /// <summary>
        /// 音频开始播放
        /// </summary>
        AUDIO_START,
        /// <summary>
        /// 音频结束
        /// </summary>
        AUDIO_FINISH,
        /// <summary>
        /// 机器人上麦
        /// </summary>
        AUDIO_ON_MIC,
        /// <summary>
        /// 机器人下麦
        /// </summary>
        AUDIO_OFF_MIC,

        // 消息审核
        /// <summary>
        /// 消息审核通过
        /// </summary>
        MESSAGE_AUDIT_PASS,
        /// <summary>
        /// 消息审核不通过
        /// </summary>
        MESSAGE_AUDIT_REJECT,

        /// <summary>
        /// 私域消息被撤回
        /// </summary>
        MESSAGE_DELETE,

        // 论坛
        /// <summary>
        /// 论坛主题创建
        /// </summary>
        FORUM_THREAD_CREATE,
        /// <summary>
        /// 论坛主题信息更新
        /// </summary>
        FORUM_THREAD_UPDATE,
        /// <summary>
        /// 论坛主题删除
        /// </summary>
        FORUM_THREAD_DELETE,
        /// <summary>
        /// 论坛帖子创建
        /// </summary>
        FORUM_POST_CREATE,
        /// <summary>
        /// 论坛帖子删除
        /// </summary>
        FORUM_POST_DELETE,
        /// <summary>
        /// 论坛帖子评论创建
        /// </summary>
        FORUM_REPLY_CREATE,
        /// <summary>
        /// 论坛帖子评论删除
        /// </summary>
        FORUM_REPLY_DELETE,
        /// <summary>
        /// 论坛主题审核结果
        /// </summary>
        FORUM_PUBLISH_AUDIT_RESULT,
        /// <summary>
        /// 互动创建
        /// </summary>
        INTERACTION_CREATE
    }
}
