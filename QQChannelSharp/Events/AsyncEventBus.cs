using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Audio;
using QQChannelSharp.Dto.Channels;
using QQChannelSharp.Dto.Forum;
using QQChannelSharp.Dto.Interactions;
using QQChannelSharp.Dto.Members;
using QQChannelSharp.Dto.Message;
using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.Enumerations;
using QQChannelSharp.Extensions;
using QQChannelSharp.WebSocket;
using System.Net.WebSockets;

namespace QQChannelSharp.Events
{
    /// <summary>
    /// 事件处理器方法委托
    /// </summary>
    /// <returns></returns>
    internal delegate Task AsyncEventHandlerFunction(WebSocketPayload payload, Session session);
    /// <summary>
    /// 异步事件总线
    /// </summary>

    // 内部维护一个事件监听字典,用来通知事件
    public class AsyncEventBus : IAsyncEventBus
    {
        private bool _disposed;
        /// <summary>
        /// 事件解析
        /// </summary>
        private readonly Dictionary<OPCode, Dictionary<string, AsyncEventHandlerFunction>> _eventParseFunc;

        public event ErrorNotifyHandler? ErrorNotify;
        public event PlainEventHandler? PlainEvent;
        public event GuildEventHandler? GuildEvent;
        public event GuildMemberEventHandler? GuildMemberEvent;
        public event ChannelEventHandler? ChannelEvent;
        public event MessageEventHandler? MessageEvent;
        public event MessageDeleteEventHandler? MessageDeleteEvent;
        public event PublicMessageDeleteEventHandler? PublicMessageDeleteEvent;
        public event DirectMessageDeleteEventHandler? DirectMessageDeleteEvent;
        public event MessageReactionEventHandler? MessageReactionEvent;
        public event ATMessageEventHandler? ATMessageEvent;
        public event DirectMessageEventHandler? DirectMessageEvent;
        public event AudioEventHandler? AudioEvent;
        public event MessageAuditEventHandler? MessageAuditEvent;
        public event ThreadEventHandler? ThreadEvent;
        public event PostEventHandler? PostEvent;
        public event ReplyEventHandler? ReplyEvent;
        public event ForumAuditEventHandler? ForumAuditEvent;
        public event InteractionEventHandler? InteractionEvent;
        public event ReadyEventHandler? Ready;
        public event ResumedEventHandler? Resumed;

        public AsyncEventBus()
        {
            _eventParseFunc = new()
            {
                {
                    OPCode.WSInvalidSession,
                    new()
                    {
                        {
                            string.Empty,
                            ErrorNotifyHandler
                        }
                    }
                },
                {
                    OPCode.WSDispatchEvent,
                    new()
                    {
                        // WS
                        {
                            "READY",
                            ReadyHandler
                        },
                        {
                            "RESUMED",
                            ResumedHandler
                        },
                        // 频道
                        {
                            "GUILD_CREATE",
                            GuildHandler
                        },
                        {
                            "GUILD_UPDATE",
                            GuildHandler
                        },
                        {
                            "GUILD_DELETE",
                            GuildHandler
                        },
                        // 子频道
                        {
                            "CHANNEL_CREATE",
                            ChannelHandler
                        },
                        {
                            "CHANNEL_UPDATE",
                            ChannelHandler
                        },
                        {
                            "CHANNEL_DELETE",
                            ChannelHandler
                        },
                        // 频道成员
                        {
                            "GUILD_MEMBER_ADD",
                            GuildMemberHandler
                        },
                        {
                            "GUILD_MEMBER_UPDATE",
                            GuildMemberHandler
                        },
                        {
                            "GUILD_MEMBER_REMOVE",
                            GuildMemberHandler
                        },
                        // 私域消息
                        {
                            "MESSAGE_CREATE",
                            MessageHandler
                        },
                        {
                            "MESSAGE_DELETE",
                            MessageDeleteHandler
                        },
                        // 消息_其他
                        {
                            "MESSAGE_REACTION_ADD",
                            MessageReactionHandler
                        },
                        {
                            "MESSAGE_REACTION_REMOVE",
                            MessageReactionHandler
                        },
                        // 公域&私域 消息
                        {
                            "AT_MESSAGE_CREATE",
                            AtMessageHandler
                        },
                        {
                            "PUBLIC_MESSAGE_DELETE",
                            PublicMessageDeleteHandler
                        },
                        // 私信
                        {
                            "DIRECT_MESSAGE_CREATE",
                            DirectMessageHandler
                        },
                        {
                            "DIRECT_MESSAGE_DELETE",
                            DirectMessageDeleteHandler
                        },
                        // 音频
                        {
                            "AUDIO_START",
                            AudioHandler
                        },
                        {
                            "AUDIO_FINISH",
                            AudioHandler
                        },
                        {
                            "AUDIO_ON_MIC",
                            AudioHandler
                        },
                        {
                            "AUDIO_OFF_MIC",
                            AudioHandler
                        },
                        // 消息审核
                        {
                            "MESSAGE_AUDIT_PASS",
                            MessageAuditHandler
                        },
                        {
                            "MESSAGE_AUDIT_REJECT",
                            MessageAuditHandler
                        },
                        // 帖子
                        // 主题
                        {
                            "FORUM_THREAD_CREATE",
                            ThreadHandler
                        },
                        {
                            "FORUM_THREAD_UPDATE",
                            ThreadHandler
                        },
                        {
                            "FORUM_THREAD_DELETE",
                            ThreadHandler
                        },
                        // 帖子
                        {
                            "FORUM_POST_CREATE",
                            PostHandler
                        },
                        {
                            "FORUM_POST_DELETE",
                            PostHandler
                        },
                        // 帖子回复
                        {
                            "FORUM_REPLY_CREATE",
                            ReplyHandler
                        },
                        {
                            "FORUM_REPLY_DELETE",
                            ReplyHandler
                        },
                        // 论坛审核
                        {
                            "FORUM_PUBLISH_AUDIT_RESULT",
                            ForumAuditHandler
                        },
                        // 其他
                        {
                            "INTERACTION_CREATE",
                            InteractionHandler
                        }
                    }
                }
            };
        }
        public async Task PublishAsync(WebSocketPayload payload, Session session)
        {
            // 查找处理字典中有没有这个事件的处理器
            if (_eventParseFunc.TryGetValue(payload.OPCode, out var message))
            {
                if (message.TryGetValue(payload.EventType?.ToUpper() ?? string.Empty, out AsyncEventHandlerFunction? func)
                    && null != func)
                {
                    await func(payload, session);
                }
            }
            else // 如果没有就通知普通消息事件
            {
                await PlainEventHandler(payload, session);
            }
        }

        public async Task PublishWebSocketErrorAsync(Session session, WebSocketException ex)
        {
            if (ErrorNotify != null)
                await ErrorNotify.Invoke(new()
                {
                    Code = ex.ErrorCode,
                    Message = ex.Message,
                    Type = ErrorType.WebSocketError
                }, session);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                _eventParseFunc.Clear();
            }
        }

        private async Task PlainEventHandler(WebSocketPayload payload, Session session)
        {
            if (PlainEvent != null)
                await PlainEvent.Invoke(payload, session);
        }

        private async Task ErrorNotifyHandler(WebSocketPayload? payload, Session session)
        {
            if (ErrorNotify != null)
                await ErrorNotify.Invoke(new()
                {
                    Code = 0,
                    Message = "invalid session: please check the intents or token",
                    Type = ErrorType.InvalidSession
                }, session);
        }

        private async Task ReadyHandler(WebSocketPayload payload, Session session)
        {
            if (Ready != null)
                await Ready.Invoke(payload, payload.GetData<WSReadyData>(), session);
        }

        private async Task ResumedHandler(WebSocketPayload payload, Session session)
        {
            if (Resumed != null)
                await Resumed.Invoke(payload, payload.GetData<WSResumeData>(), session);
        }

        private async Task GuildHandler(WebSocketPayload payload, Session session)
        {
            if (GuildEvent != null)
                await GuildEvent.Invoke(payload, payload.GetData<Guild>(), session);
        }

        private async Task ChannelHandler(WebSocketPayload payload, Session session)
        {
            if (ChannelEvent != null)
                await ChannelEvent.Invoke(payload, payload.GetData<Channel>(), session);
        }

        private async Task GuildMemberHandler(WebSocketPayload payload, Session session)
        {
            if (GuildMemberEvent != null)
                await GuildMemberEvent.Invoke(payload, payload.GetData<Member>(), session);
        }

        private async Task MessageHandler(WebSocketPayload payload, Session session)
        {
            if (MessageEvent != null)
                await MessageEvent.Invoke(payload, payload.GetData<Message>(), session);
        }

        private async Task MessageDeleteHandler(WebSocketPayload payload, Session session)
        {
            if (MessageDeleteEvent != null)
                await MessageDeleteEvent.Invoke(payload, payload.GetData<MessageDelete>(), session);
        }

        private async Task MessageReactionHandler(WebSocketPayload payload, Session session)
        {
            if (MessageReactionEvent != null)
                await MessageReactionEvent.Invoke(payload, payload.GetData<MessageReaction>(), session);
        }

        private async Task AtMessageHandler(WebSocketPayload payload, Session session)
        {
            if (ATMessageEvent != null)
                await ATMessageEvent.Invoke(payload, payload.GetData<Message>(), session);
        }

        private async Task PublicMessageDeleteHandler(WebSocketPayload payload, Session session)
        {
            if (PublicMessageDeleteEvent != null)
                await PublicMessageDeleteEvent.Invoke(payload, payload.GetData<MessageDelete>(), session);
        }

        private async Task DirectMessageHandler(WebSocketPayload payload, Session session)
        {
            if (DirectMessageEvent != null)
                await DirectMessageEvent.Invoke(payload, payload.GetData<Message>(), session);
        }

        private async Task DirectMessageDeleteHandler(WebSocketPayload payload, Session session)
        {
            if (DirectMessageDeleteEvent != null)
                await DirectMessageDeleteEvent.Invoke(payload, payload.GetData<MessageDelete>(), session);
        }

        private async Task AudioHandler(WebSocketPayload payload, Session session)
        {
            if (AudioEvent != null)
                await AudioEvent.Invoke(payload, payload.GetData<AudioAction>(), session);
        }

        private async Task MessageAuditHandler(WebSocketPayload payload, Session session)
        {
            if (MessageAuditEvent != null)
                await MessageAuditEvent.Invoke(payload, payload.GetData<MessageAudit>(), session);
        }

        private async Task ThreadHandler(WebSocketPayload payload, Session session)
        {
            if (ThreadEvent != null)
                await ThreadEvent.Invoke(payload, payload.GetData<Dto.Forum.Thread>(), session);
        }

        private async Task PostHandler(WebSocketPayload payload, Session session)
        {
            if (PostEvent != null)
                await PostEvent.Invoke(payload, payload.GetData<Post>(), session);
        }

        private async Task ReplyHandler(WebSocketPayload payload, Session session)
        {
            if (ReplyEvent != null)
                await ReplyEvent.Invoke(payload, payload.GetData<Reply>(), session);
        }

        private async Task ForumAuditHandler(WebSocketPayload payload, Session session)
        {
            if (ForumAuditEvent != null)
                await ForumAuditEvent.Invoke(payload, payload.GetData<ForumAuditResult>(), session);
        }

        private async Task InteractionHandler(WebSocketPayload payload, Session session)
        {
            if (InteractionEvent != null)
                await InteractionEvent.Invoke(payload, payload.GetData<Interaction>(), session);
        }
    }
}
