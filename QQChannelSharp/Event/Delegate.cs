using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Audio;
using QQChannelSharp.Dto.Channels;
using QQChannelSharp.Dto.Forum;
using QQChannelSharp.Dto.Interactions;
using QQChannelSharp.Dto.Members;
using QQChannelSharp.Dto.Message;
using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.WebSocket;

namespace QQChannelSharp.Events;

public delegate Task QQChannelAsyncCall

/// <summary>
/// Bot鉴权成功事件
/// </summary>
public delegate Task ReadyEventHandler(WebSocketPayload payload, WSReadyData data, Session session);

/// <summary>
/// Bot重连成功
/// </summary>
public delegate Task ResumedEventHandler(WebSocketPayload payload, WSResumeData data, Session session);

/// <summary>
/// ErrorNotifyHandler 当 ws 连接发生错误的时候，会回调，方便使用方监控相关错误
/// 比如 reconnect invalidSession 等错误
/// </summary>
public delegate Task ErrorNotifyHandler(ErrorNotify error, Session session);

/// <summary>
/// 透传handler
/// </summary>
public delegate Task PlainEventHandler(WebSocketPayload payload, Session session);

/// <summary>
/// 频道事件Handler
/// </summary>
public delegate Task GuildEventHandler(WebSocketPayload payload, Guild data, Session session);
/// <summary>
/// 频道成员事件
/// </summary>
public delegate Task GuildMemberEventHandler(WebSocketPayload payload, Member data, Session session);

/// <summary>
/// 子频道事件
/// </summary>
public delegate Task ChannelEventHandler(WebSocketPayload payload, Channel data, Session session);

/// <summary>
/// 私域消息事件
/// </summary>
public delegate Task MessageEventHandler(WebSocketPayload payload, Message data, Session session);
/// <summary>
/// 消息撤回事件
/// </summary>
public delegate Task MessageDeleteEventHandler(WebSocketPayload payload, MessageDelete data, Session session);
/// <summary>
/// 公域消息撤回事件
/// </summary>
public delegate Task PublicMessageDeleteEventHandler(WebSocketPayload payload, MessageDelete data, Session session);
/// <summary>
/// 私信消息撤回事件
/// </summary>
public delegate Task DirectMessageDeleteEventHandler(WebSocketPayload payload, MessageDelete data, Session session);

/// <summary>
/// 表情表态事件
/// </summary>
public delegate Task MessageReactionEventHandler(WebSocketPayload payload, MessageReaction data, Session session);

/// <summary>
/// @消息
/// </summary>
public delegate Task ATMessageEventHandler(WebSocketPayload payload, Message data, Session session);
/// <summary>
/// 私信消息
/// </summary>
public delegate Task DirectMessageEventHandler(WebSocketPayload payload, Message data, Session session);

/// <summary>
/// 音频事件
/// </summary>
public delegate Task AudioEventHandler(WebSocketPayload payload, AudioAction data, Session session);

/// <summary>
/// 消息审核事件
/// </summary>
public delegate Task MessageAuditEventHandler(WebSocketPayload payload, MessageAudit data, Session session);

// 论坛

/// <summary>
/// 论坛主题事件
/// </summary>
public delegate Task ThreadEventHandler(WebSocketPayload payload, Dto.Forum.Thread data, Session session);
/// <summary>
/// 论坛帖子事件 (帖子=主题的评论!=主题)
/// </summary>
public delegate Task PostEventHandler(WebSocketPayload payload, Post data, Session session);
/// <summary>
/// 帖子回复事件 (帖子=主题的评论!=主题)
/// </summary>
public delegate Task ReplyEventHandler(WebSocketPayload payload, Reply data, Session session);
/// <summary>
/// 论坛审核事件
/// </summary>
public delegate Task ForumAuditEventHandler(WebSocketPayload payload, ForumAuditResult data, Session session);

/// <summary>
/// 互动事件
/// </summary>
public delegate Task InteractionEventHandler(WebSocketPayload payload, Interaction data, Session session);