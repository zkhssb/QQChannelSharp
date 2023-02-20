using System.ComponentModel;

namespace QQChannelSharp.Enumerations
{
    /// <summary>
    /// 事件订阅intents枚举
    /// </summary>
    public enum Intents : int
    {
        // 这里的Description特性是为了留给Windows桌面客户端读取用的(可以不用在意)

        /// <summary>
        /// 频道事件
        /// </summary>
        [Description("频道事件")]
        GUILDS = 1 << 0,
        /// <summary>
        /// 频道成员事件
        /// </summary>
        [Description("频道成员事件")]
        GUILD_MEMBERS = 1 << 1,
        /// <summary>
        /// 私域机器人消息事件
        /// </summary>
        [Description("私域机器人消息事件")]
        GUILD_MESSAGES = 1 << 9,
        /// <summary>
        /// 频道表情表态事件
        /// </summary>
        [Description("频道表情表态事件")]
        GUILD_MESSAGE_REACTIONS = 1 << 10,
        /// <summary>
        /// 私信消息事件
        /// </summary>
        [Description("私信消息事件")]
        DIRECT_MESSAGE = 1 << 12,
        /// <summary>
        /// 公域论坛事件
        /// </summary>
        [Description("公域论坛事件")]
        OPEN_FORUMS_EVENT = 1 << 18,
        /// <summary>
        /// 音视频(包含直播)子频道进出事件
        /// </summary>
        [Description("音视频(包含直播)子频道进出事件")]
        AUDIO_OR_LIVE_CHANNEL_MEMBER = 1 << 19,
        /// <summary>
        /// 互动事件
        /// </summary>
        [Description("互动事件")]
        INTERACTION = 1 << 26,
        /// <summary>
        /// 消息审核事件
        /// </summary>
        [Description("消息审核事件")]
        MESSAGE_AUDIT = 1 << 27,
        /// <summary>
        /// 私域论坛事件
        /// </summary>
        [Description("私域论坛事件")]
        PRIVATE_FORUMS_EVENT = 1 << 28,
        /// <summary>
        /// 音频事件
        /// </summary>
        [Description("音频事件")]
        AUDIO_ACTION = 1 << 29,
        /// <summary>
        /// 公域消息事件
        /// </summary>
        [Description("公域消息事件")]
        PUBLIC_GUILD_MESSAGES = 1 << 30,
    }
}
