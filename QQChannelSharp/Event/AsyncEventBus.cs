using QQChannelSharp.Attributes;
using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Audio;
using QQChannelSharp.Dto.Channels;
using QQChannelSharp.Dto.Forum;
using QQChannelSharp.Dto.Interactions;
using QQChannelSharp.Dto.Members;
using QQChannelSharp.Dto.Message;
using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.Enumerations;
using QQChannelSharp.EventArgs;
using QQChannelSharp.Extensions;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Logger;
using QQChannelSharp.OpenApi;
using QQChannelSharp.WebSocket;
using System.Net.WebSockets;
using System.Reflection;

namespace QQChannelSharp.Events
{
    /// <summary>
    /// 事件处理器方法委托
    /// </summary>
    /// <returns></returns>
    internal delegate Task AsyncEventHandlerFunction(WebSocketPayload payload, Session session, IOpenApi openApi);
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
        private readonly IOpenApi _openApi;

        public event EventAsyncCallBackHandler<ReadyEvent>? Ready;
        public event EventAsyncCallBackHandler<ResumedEvent>? Resumed;
        public event EventAsyncCallBackHandler<ErrorNotifyEvent>? ErrorNotify;
        public event EventAsyncCallBackHandler<PlainEvent>? PlainEvent;
        public event EventAsyncCallBackHandler<GuildEvent>? GuildEvent;
        public event EventAsyncCallBackHandler<GuildMemberEvent>? GuildMemberEvent;
        public event EventAsyncCallBackHandler<ChannelEvent>? ChannelEvent;
        public event EventAsyncCallBackHandler<MessageEvent>? MessageEvent;
        public event EventAsyncCallBackHandler<MessageDeleteEvent>? MessageDeleteEvent;
        public event EventAsyncCallBackHandler<PublicMessageDeleteEvent>? PublicMessageDeleteEvent;
        public event EventAsyncCallBackHandler<DirectMessageDeleteEvent>? DirectMessageDeleteEvent;
        public event EventAsyncCallBackHandler<MessageReactionEvent>? MessageReactionEvent;
        public event EventAsyncCallBackHandler<ATMessageEvent>? ATMessageEvent;
        public event EventAsyncCallBackHandler<DirectMessageEvent>? DirectMessageEvent;
        public event EventAsyncCallBackHandler<AudioEvent>? AudioEvent;
        public event EventAsyncCallBackHandler<MessageAuditEvent>? MessageAuditEvent;
        public event EventAsyncCallBackHandler<ThreadEvent>? ThreadEvent;
        public event EventAsyncCallBackHandler<PostEvent>? PostEvent;
        public event EventAsyncCallBackHandler<ReplyEvent>? ReplyEvent;
        public event EventAsyncCallBackHandler<ForumAuditEvent>? ForumAuditEvent;
        public event EventAsyncCallBackHandler<InteractionEvent>? InteractionEvent;
        public event EventAsyncCallBackHandler<HandlerErrorEvent>? HandlerErrorEvent;

        public AsyncEventBus(IOpenApi openApi)
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
            _openApi = openApi;
        }
        public async Task PublishAsync(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            try
            {
                // 查找处理字典中有没有这个事件的处理器
                if (_eventParseFunc.TryGetValue(payload.OPCode, out var message))
                {
                    if (message.TryGetValue(payload.EventType?.ToUpper() ?? string.Empty, out AsyncEventHandlerFunction? func)
                        && null != func)
                    {
                        await func(payload, session, openApi);
                    }
                }
                else // 如果没有就通知普通消息事件
                {
                    await PlainEventHandler(payload, session, openApi);
                }
            }
            catch (Exception ex)
            {
                if (null != HandlerErrorEvent)
                    await HandlerErrorEvent(new()
                    {
                        OpenApi = openApi,
                        Exception = ex,
                        Payload = payload,
                        Session = session
                    });
                else
                {
                    Log.LogFatal("EventBus", ex.ToString(), false);
                }
            }
        }

        public async Task PublishWebSocketErrorAsync(Session session, WebSocketException ex, IOpenApi openApi)
        {
            if (ErrorNotify != null)
                await ErrorNotify.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = new(),
                    Error = new()
                    {
                        Code = ex.ErrorCode,
                        Message = ex.Message,
                        Type = ErrorType.WebSocketError
                    },
                    Session = session
                });
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                _eventParseFunc.Clear();
            }
        }

        private async Task PlainEventHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (PlainEvent != null)
                await PlainEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session
                });
        }

        private async Task ErrorNotifyHandler(WebSocketPayload? payload, Session session, IOpenApi openApi)
        {
            if (ErrorNotify != null)
                await ErrorNotify.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload ?? new(),
                    Session = session,
                    Error = new()
                    {
                        Code = 0,
                        Message = "invalid session: please check the intents or token",
                        Type = ErrorType.InvalidSession
                    }
                });
        }

        private async Task ReadyHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (Ready != null)
                await Ready.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    ReadyData = payload.GetData<WSReadyData>()
                });
        }

        private async Task ResumedHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (Resumed != null)
                await Resumed.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    ResumeData = payload.GetData<WSResumeData>()
                });
        }

        private async Task GuildHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (GuildEvent != null)
                await GuildEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    EventGuild = payload.GetData<Guild>(),
                    EventType = payload.GetEventType(),
                    Type = payload.GetEventType().GetStateChangeType(),
                });
        }

        private async Task ChannelHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (ChannelEvent != null)
                await ChannelEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    EventType = payload.GetEventType(),
                    Type = payload.GetEventType().GetStateChangeType(),
                    Channel = payload.GetData<Channel>(),
                });
        }

        private async Task GuildMemberHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (GuildMemberEvent != null)
                await GuildMemberEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    EventType = payload.GetEventType(),
                    Type = payload.GetEventType().GetStateChangeType(),
                    Member = payload.GetData<Member>(),
                });
        }

        private async Task MessageHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (MessageEvent != null)
                await MessageEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    Message = payload.GetData<Message>(),
                });
        }

        private async Task MessageDeleteHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (MessageDeleteEvent != null)
                await MessageDeleteEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    MessageDelete = payload.GetData<MessageDelete>(),
                });
        }

        private async Task MessageReactionHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (MessageReactionEvent != null)
                await MessageReactionEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    EventType = payload.GetEventType(),
                    Type = payload.GetEventType().GetStateChangeType(),
                    Reaction = payload.GetData<MessageReaction>(),
                });
        }

        private async Task AtMessageHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (ATMessageEvent != null)
                await ATMessageEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    Message = payload.GetData<Message>(),
                });
        }

        private async Task PublicMessageDeleteHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (PublicMessageDeleteEvent != null)
                await PublicMessageDeleteEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    MessageDelete = payload.GetData<MessageDelete>(),
                });
        }

        private async Task DirectMessageHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (DirectMessageEvent != null)
                await DirectMessageEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    Message = payload.GetData<Message>(),
                });
        }

        private async Task DirectMessageDeleteHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (DirectMessageDeleteEvent != null)
                await DirectMessageDeleteEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    MessageDelete = payload.GetData<MessageDelete>(),
                });
        }

        private async Task AudioHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (AudioEvent != null)
                await AudioEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    EventType = payload.GetEventType(),
                    Type = payload.GetEventType().GetAudioEventType(),
                    Action = payload.GetData<AudioAction>(),
                });
        }

        private async Task MessageAuditHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (MessageAuditEvent != null)
                await MessageAuditEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    Result = payload.GetEventType().GetMessageAuditType(),
                    Audit = payload.GetData<MessageAudit>(),
                });
        }

        private async Task ThreadHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (ThreadEvent != null)
                await ThreadEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    Thread = payload.GetData<Dto.Forum.Thread>(),
                    EventType = payload.GetEventType(),
                    Type = payload.GetEventType().GetStateChangeType()
                });
        }

        private async Task PostHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (PostEvent != null)
                await PostEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    Post = payload.GetData<Dto.Forum.Post>(),
                    EventType = payload.GetEventType(),
                    Type = payload.GetEventType().GetStateChangeType()
                });
        }

        private async Task ReplyHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (ReplyEvent != null)
                await ReplyEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    Reply = payload.GetData<Dto.Forum.Reply>(),
                    EventType = payload.GetEventType(),
                    Type = payload.GetEventType().GetStateChangeType()
                });
        }

        private async Task ForumAuditHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (ForumAuditEvent != null)
                await ForumAuditEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    Result = payload.GetData<ForumAuditResult>(),
                });
        }

        private async Task InteractionHandler(WebSocketPayload payload, Session session, IOpenApi openApi)
        {
            if (InteractionEvent != null)
                await InteractionEvent.Invoke(new()
                {
                    OpenApi = openApi,
                    Payload = payload,
                    Session = session,
                    Interaction = payload.GetData<Interaction>(),
                    EventType = payload.GetEventType(),
                    Type = payload.GetEventType().GetStateChangeType()
                });
        }

        public void Subscribe(object listener)
        {
            var handlers = listener.GetType()
                .GetMethods()
                .Where(e => e.GetCustomAttribute(typeof(EventHandlerAttribute)) != null)
                .ToArray();
            if (handlers.Length <= 0)
                throw new ArgumentException("对象没有任何EventHandlerAttribute特性标记");

            // 开始尝试注册
            foreach (var handler in handlers)
            {
                var parameters = handler.GetParameters();
                if (1 < parameters.Length)
                {
                    // 方法只能有一个参数,且必须继承BaseChannelEventArgs
                    Log.LogError("Subscribe", $"{listener.GetType().FullName}.{handler.Name}只能有一个参数");
                }
                else if (CheckMethod(handler))
                {
                    if (handler.ReturnType != typeof(ValueTask))
                        Log.LogError("Subscribe", $"{listener.GetType().FullName}.{handler.Name}的返回值必须是ValueTask!");

                    foreach (var item in GetType().GetEvents())
                    {
                        // 获取事件的泛型类型
                        var genericType = item.EventHandlerType!.GenericTypeArguments[0];
                        if (genericType != parameters[0].ParameterType) continue; // 如果事件泛型类型不是要订阅的事件类型就跳出
                        item.AddEventHandler(this, Delegate.CreateDelegate(item.EventHandlerType, listener, handler));
                    }

                }
                else
                {
                    // 方法只能有一个参数,且必须继承BaseChannelEventArgs
                    Log.LogError("Subscribe", $"{listener.GetType().FullName}.{handler.Name}的唯一参数必须继承BaseChannelEventArgs!");
                }
            }

            // 检查方法是否合法
            static bool CheckMethod(MethodInfo method)
            {
                ParameterInfo[] parameters = method.GetParameters();

                // 如果长度不是1 那么不符合, 方法只能有一个参数
                // 如果唯一的参数不继承BaseChannelEventArgs 那么代表这不是个事件
                return
                    parameters.Length == 1
                    && parameters[0].ParameterType.IsAssignableTo(typeof(BaseChannelEventArgs));
            }
        }
    }
}
