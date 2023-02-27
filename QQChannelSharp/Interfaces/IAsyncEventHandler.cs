using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.WebSocket;

namespace QQChannelSharp.Interfaces
{
    public interface IAsyncEventHandler
    {
        /// <summary>
        /// 普通事件处理
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="session"></param>
        public Task PlainEventHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 错误通知事件
        /// </summary>
        public Task ErrorNotifyHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// BOT准本好了! 事件
        /// </summary>
        public Task ReadyHandler(WebSocketPayload payload, Session session);

        /// <summary>
        /// 频道事件
        /// </summary>
        public Task GuildHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 子频道事件
        /// </summary>
        public Task ChannelHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 频道成员
        /// </summary>
        public Task GuildMemberHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 私域消息事件
        /// </summary>
        public Task MessageHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 消息撤回
        /// </summary>
        public Task MessageDeleteHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 表情表态
        /// </summary>
        public Task MessageReactionHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// @消息处理器
        /// </summary>
        public Task AtMessageHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 公域消息撤回
        /// </summary>
        public Task PublicMessageDeleteHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 私信消息
        /// </summary>
        public Task DirectMessageHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 音频事件
        /// </summary>
        public Task AudioHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 消息审核
        /// </summary>
        public Task MessageAuditHandler(WebSocketPayload payload, Session session);

        // 论坛↓
        /// <summary>
        /// 主题事件
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="session"></param>
        public Task ThreadHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 帖子(评论)事件
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="session"></param>
        public Task PostHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 帖子回复事件
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="session"></param>
        public Task ReplyHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 论坛审核事件
        /// </summary>
        public Task ForumAuditHandler(WebSocketPayload payload, Session session);
        /// <summary>
        /// 互动事件
        /// </summary>
        public Task InteractionHandler(WebSocketPayload payload, Session session);

    }
}
