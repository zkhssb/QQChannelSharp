using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.Enumerations;
using QQChannelSharp.Interfaces;
using QQChannelSharp.WebSocket;
using System.Reactive.Linq;
using System.Reactive.Subjects;

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
        private readonly IAsyncEventHandler _handler;

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

        public AsyncEventBus()
        {
            _handler = new AsyncEventHandler(this);
            _eventParseFunc = new()
            {
                {
                    OPCode.WSDispatchEvent,
                    new()
                    {
                        // 频道
                        {
                            "GUILD_CREATE",
                            _handler.GuildHandler
                        },
                        {
                            "GUILD_UPDATE",
                            _handler.GuildHandler
                        },
                        {
                            "GUILD_DELETE",
                            _handler.GuildHandler
                        },
                        // 子频道
                        {
                            "CHANNEL_CREATE",
                            _handler.ChannelHandler
                        },
                        {
                            "CHANNEL_UPDATE",
                            _handler.ChannelHandler
                        },
                        {
                            "CHANNEL_DELETE",
                            _handler.ChannelHandler
                        },
                        // 频道成员
                        {
                            "GUILD_MEMBER_ADD",
                            _handler.GuildMemberHandler
                        },
                        {
                            "GUILD_MEMBER_UPDATE",
                            _handler.GuildMemberHandler
                        },
                        {
                            "GUILD_MEMBER_REMOVE",
                            _handler.GuildMemberHandler
                        },
                        // 私域消息
                        {
                            "MESSAGE_CREATE",
                            _handler.MessageHandler
                        },
                        {
                            "MESSAGE_DELETE",
                            _handler.MessageDeleteHandler
                        },
                        // 消息_其他
                        {
                            "MESSAGE_REACTION_ADD",
                            _handler.MessageReactionHandler
                        },
                        {
                            "MESSAGE_REACTION_REMOVE",
                            _handler.MessageReactionHandler
                        },
                        // 公域&私域 消息
                        {
                            "AT_MESSAGE_CREATE",
                            _handler.AtMessageHandler
                        },
                        {
                            "PUBLIC_MESSAGE_DELETE",
                            _handler.PublicMessageDeleteHandler
                        },
                        // 私信
                        {
                            "DIRECT_MESSAGE_CREATE",
                            _handler.DirectMessageHandler
                        },
                        {
                            "DIRECT_MESSAGE_DELETE",
                            _handler.DirectMessageHandler
                        },
                        // 音频
                        {
                            "AUDIO_START",
                            _handler.AudioHandler
                        },
                        {
                            "AUDIO_FINISH",
                            _handler.AudioHandler
                        },
                        {
                            "AUDIO_ON_MIC",
                            _handler.AudioHandler
                        },
                        {
                            "AUDIO_OFF_MIC",
                            _handler.AudioHandler
                        },
                        // 消息审核
                        {
                            "MESSAGE_AUDIT_PASS",
                            _handler.MessageAuditHandler
                        },
                        {
                            "MESSAGE_AUDIT_REJECT",
                            _handler.MessageAuditHandler
                        },
                        // 帖子
                        // 主题
                        {
                            "FORUM_THREAD_CREATE",
                            _handler.ThreadHandler
                        },
                        {
                            "FORUM_THREAD_UPDATE",
                            _handler.ThreadHandler
                        },
                        {
                            "FORUM_THREAD_DELETE",
                            _handler.ThreadHandler
                        },
                        // 帖子
                        {
                            "FORUM_POST_CREATE",
                            _handler.PostHandler
                        },
                        {
                            "FORUM_POST_DELETE",
                            _handler.PostHandler
                        },
                        // 帖子回复
                        {
                            "FORUM_REPLY_CREATE",
                            _handler.ReplyHandler
                        },
                        {
                            "FORUM_REPLY_DELETE",
                            _handler.ReplyHandler
                        },
                        // 论坛审核
                        {
                            "FORUM_PUBLISH_AUDIT_RESULT",
                            _handler.ForumAuditHandler
                        },
                        // 其他
                        {
                            "INTERACTION_CREATE",
                            _handler.InteractionHandler
                        }
                    }
                }
            };
        }
        public async Task PublishAsync(WebSocketPayload payload, Session session)
        {
            // 先查找处理字典中有没有这个事件的处理器
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
                await _handler.PlainEventHandler(payload, session);
            }
        }

        public void Subscribe()
        {
        }

        public void Unsubscribe()
        {

        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                _eventParseFunc.Clear();
            }
        }
    }
}
