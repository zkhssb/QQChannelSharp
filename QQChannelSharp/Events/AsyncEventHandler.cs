using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.Interfaces;
using QQChannelSharp.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQChannelSharp.Events
{
    /// <summary>
    /// 内部事件处理器
    /// </summary>
    public class AsyncEventHandler : IAsyncEventHandler
    {
        private readonly IAsyncEventBus _eventBus;
        public AsyncEventHandler(IAsyncEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task AtMessageHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task AudioHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task ChannelHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task DirectMessageHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task ErrorNotifyHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task ForumAuditHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task GuildHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task GuildMemberHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task InteractionHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task MessageAuditHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task MessageDeleteHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task MessageHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task MessageReactionHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task PlainEventHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task PostHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task PublicMessageDeleteHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task ReadyHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task ReplyHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }

        public Task ThreadHandler(WebSocketPayload payload, Session session)
        {
            throw new NotImplementedException();
        }
    }
}
