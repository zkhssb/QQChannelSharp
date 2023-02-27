using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.WebSocket;

namespace QQChannelSharp.Events
{
    public interface IAsyncEventBus : IDisposable
    {
        /// <summary>
        /// 错误通知
        /// </summary>
        event ErrorNotifyHandler? ErrorNotify;
        /// <summary>
        /// 普通事件
        /// </summary>
        event PlainEventHandler? PlainEvent;
        /// <summary>
        /// 频道事件
        /// </summary>
        event GuildEventHandler? GuildEvent;
        /// <summary>
        /// 频道成员事件
        /// </summary>
        event GuildMemberEventHandler? GuildMemberEvent;
        /// <summary>
        /// 子频道事件
        /// </summary>
        event ChannelEventHandler? ChannelEvent;
        /// <summary>
        /// 私域消息事件
        /// </summary>
        event MessageEventHandler? MessageEvent;
        /// <summary>
        /// 私域消息撤回事件
        /// </summary>
        event MessageDeleteEventHandler? MessageDeleteEvent;
        /// <summary>
        /// 公域消息撤回事件
        /// </summary>
        event PublicMessageDeleteEventHandler? PublicMessageDeleteEvent;
        /// <summary>
        /// 私信消息撤回事件
        /// </summary>
        event DirectMessageDeleteEventHandler? DirectMessageDeleteEvent;
        /// <summary>
        /// 消息表情表态事件
        /// </summary>
        event MessageReactionEventHandler? MessageReactionEvent;
        /// <summary>
        /// @消息事件
        /// </summary>
        event ATMessageEventHandler? ATMessageEvent;
        /// <summary>
        /// 私信消息事件
        /// </summary>
        event DirectMessageEventHandler? DirectMessageEvent;
        /// <summary>
        /// 音频事件
        /// </summary>
        event AudioEventHandler? AudioEvent;
        /// <summary>
        /// 消息审核事件
        /// </summary>
        event MessageAuditEventHandler? MessageAuditEvent;
        /// <summary>
        /// 论坛主题事件
        /// </summary>
        event ThreadEventHandler? ThreadEvent;
        /// <summary>
        /// 论坛主题帖子事件 (评论)
        /// </summary>
        event PostEventHandler? PostEvent;
        /// <summary>
        /// 论坛主题帖子回复事件 (回复评论)
        /// </summary>
        event ReplyEventHandler? ReplyEvent;
        /// <summary>
        /// 论坛审核事件
        /// </summary>
        event ForumAuditEventHandler? ForumAuditEvent;
        /// <summary>
        /// 互动事件
        /// </summary>
        event InteractionEventHandler? InteractionEvent;

        /// <summary>
        /// 推送事件
        /// </summary>
        Task PublishAsync(WebSocketPayload payload, Session session);
    }
}
