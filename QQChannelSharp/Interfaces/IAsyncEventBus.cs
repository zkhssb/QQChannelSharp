using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.EventArgs;
using QQChannelSharp.WebSocket;
using System.Net.WebSockets;

namespace QQChannelSharp.Events
{
    public interface IAsyncEventBus : IDisposable
    {
        /// <summary>
        /// 机器人鉴权成功
        /// </summary>
        event EventAsyncCallBackHandler<ReadyEvent>? Ready;
        /// <summary>
        /// 机器人重连成功
        /// </summary>
        event EventAsyncCallBackHandler<ResumedEvent>? Resumed;
        /// <summary>
        /// 错误通知
        /// </summary>
        event EventAsyncCallBackHandler<ErrorNotifyEvent>? ErrorNotify;
        /// <summary>
        /// 普通事件
        /// </summary>
        event EventAsyncCallBackHandler<PlainEvent>? PlainEvent;
        /// <summary>
        /// 频道事件
        /// </summary>
        event EventAsyncCallBackHandler<GuildEvent>? GuildEvent;
        /// <summary>
        /// 频道成员事件
        /// </summary>
        event EventAsyncCallBackHandler<GuildMemberEvent>? GuildMemberEvent;
        /// <summary>
        /// 子频道事件
        /// </summary>
        event EventAsyncCallBackHandler<ChannelEvent>? ChannelEvent;
        /// <summary>
        /// 私域消息事件
        /// </summary>
        event EventAsyncCallBackHandler<MessageEvent>? MessageEvent;
        /// <summary>
        /// 私域消息撤回事件
        /// </summary>
        event EventAsyncCallBackHandler<MessageDeleteEvent>? MessageDeleteEvent;
        /// <summary>
        /// 公域消息撤回事件
        /// </summary>
        event EventAsyncCallBackHandler<PublicMessageDeleteEvent>? PublicMessageDeleteEvent;
        /// <summary>
        /// 私信消息撤回事件
        /// </summary>
        event EventAsyncCallBackHandler<DirectMessageDeleteEvent>? DirectMessageDeleteEvent;
        /// <summary>
        /// 消息表情表态事件
        /// </summary>
        event EventAsyncCallBackHandler<MessageReactionEvent>? MessageReactionEvent;
        /// <summary>
        /// @消息事件
        /// </summary>
        event EventAsyncCallBackHandler<ATMessageEvent>? ATMessageEvent;
        /// <summary>
        /// 私信消息事件
        /// </summary>
        event EventAsyncCallBackHandler<DirectMessageEvent>? DirectMessageEvent;
        /// <summary>
        /// 音频事件
        /// </summary>
        event EventAsyncCallBackHandler<AudioEvent>? AudioEvent;
        /// <summary>
        /// 消息审核事件
        /// </summary>
        event EventAsyncCallBackHandler<MessageAuditEvent>? MessageAuditEvent;
        /// <summary>
        /// 论坛主题事件
        /// </summary>
        event EventAsyncCallBackHandler<ThreadEvent>? ThreadEvent;
        /// <summary>
        /// 论坛主题帖子事件 (评论)
        /// </summary>
        event EventAsyncCallBackHandler<PostEvent>? PostEvent;
        /// <summary>
        /// 论坛主题帖子回复事件 (回复评论)
        /// </summary>
        event EventAsyncCallBackHandler<ReplyEvent>? ReplyEvent;
        /// <summary>
        /// 论坛审核事件
        /// </summary>
        event EventAsyncCallBackHandler<ForumAuditEvent>? ForumAuditEvent;
        /// <summary>
        /// 互动事件
        /// </summary>
        event EventAsyncCallBackHandler<InteractionEvent>? InteractionEvent;
        /// <summary>
        /// 监听事件的处理器发生异常时的事件
        /// </summary>
        event EventAsyncCallBackHandler<HandlerErrorEvent>? HandlerErrorEvent;

        /// <summary>
        /// 推送事件
        /// </summary>
        Task PublishAsync(WebSocketPayload payload, Session session);
        /// <summary>
        /// 推送WebSocket错误
        /// </summary>
        Task PublishWebSocketErrorAsync(Session session, WebSocketException ex);

        /// <summary>
        /// 注册一个监听器
        /// </summary>
        void Subscribe(object listener);
    }
}
