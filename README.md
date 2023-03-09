<h1 align="center">
<img src="QQChannelSharp/Icon.png" />
<br />
QQChannelSharp
<br />
<h4 align="center">
    使用
    <a href="https://dotnet.microsoft.com/download/dotnet/7.0">.NET 7.0</a>
    开发的异步频道机器人开发框架
</h4>
<h4 align="center">
<a href="https://www.nuget.org/packages/QQChannelSharp/">
<img src="https://img.shields.io/nuget/v/QQChannelSharp?style=flat-square" alt="nuget" />
</a>
​ <a href="https://www.apache.org/licenses/LICENSE-2.0">
​ <img src="https://img.shields.io/github/license/zkhssb/QQChannelSharp?style=flat-square&color=blueviolet"
​ alt="license" />
​ </a>
​ <img src="https://img.shields.io/badge/.NET-7.0-blue" />
​ <a href="https://bot.q.qq.com/wiki/develop/api/">
​ <img src="https://img.shields.io/badge/OpenApi-V1-blue" />
​ </a>
​ <img src="https://img.shields.io/github/actions/workflow/status/zkhssb/QQChannelSharp/dotnet.yml?branch=master&&style=flat-square"
​ alt="workflow" />
​ </h4>
​ </h1>

## 文档

<a href="https://www.yuque.com/miuxue/gh07pk" target="_blank">语雀文档</a>

## 能力

- OpenApi拥有错误重试能力
- 支持机器人`本地`/`远程`会话管理器 `Remote正在计划中`
- 异步开发: 异步OpenApi, 异步事件处理

<details>
  <summary>支持的事件</summary>

- ATMessageEvent - 公域机器人AT消息
- AudioEvent - 音频事件消息
- ChannelEvent - 频道事件
- DirectMessageDeleteEvent - 私信消息删除事件
- DirectMessageEvent - 私信消息事件
- ErrorNotifyEvent - WebSocket错误通知事件
- ForumAuditEvent - 论坛审核事件
- GuildEvent - 频道事件
- GuildMemberEvent - 频道成员事件
- HandlerErrorEvent - 事件处理监听器错误事件
- InteractionEvent - 互动事件
- MessageAuditEvent - 消息审核事件
- MessageDeleteEvent - 消息删除事件
- MessageEvent - 私域机器人消息事件
- MessageReactionEvent - 消息表情表态事件
- PlainEvent - 普通事件
- PostEvent - 主题帖子事件
- PublicMessageDeleteEvent - 公域消息撤回事件
- ReadyEvent - 机器人鉴权成功事件
- ReplyEvent - 主题帖子回复事件
- ResumedEvent - 机器人重连成功事件
- ThreadEvent - 论坛主题事件
</details>

<details>
  <summary>待实现接口 (V1)</summary>

- WEBHOOK

</details>

---

## 问题反馈

该项目属于测试阶段,如遇bug或者有想法/建议 请打开issue

### 交流

在使用中有任何疑问可以加入我们的[QQ频道](https://pd.qq.com/s/6ndoh4n4v)

---

## 依赖的开源库

> [RestSharp](https://github.com/restsharp/RestSharp) | .NET HTTPAPI客户端

---

## 快速开始

新建一个.NET7 项目,并从 Github 或 Nuget 上导入 QQChannelSharp。

在 Program 中引入必要的命名空间

```csharp
using QQChannelSharp;
using QQChannelSharp.Example.Handlers;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Logger;
using QQChannelSharp.OpenApi;
using QQChannelSharp.Sessions;
```

### 设置日志

日志默认会启用输出, 且日志等级为 Info

```csharp
Log.Configuration
	.EnableConsoleOutput()
    .SetLogLevel(LogLevel.Info);
```

## 启动本地会话

在启动本地会话之前，需要创建一个机器人信息和 OpenApi。这些数据将最终传递到一个会话管理器中，用于管理机器人的分片和事件的分发。创建完毕后，您可以通过调用会话管理器中的方法来注册一个类，或直接使用运算符相加将会话管理器事件总线中公开的事件注册为事件处理器。

这边演示最简单的 直接使用+=注册事件

需要更高级的订阅请参考文档: [事件订阅](https://www.yuque.com/miuxue/gh07pk/vifx049dwagm3kg7)

```csharp
ChannelBotInfo botInfo = new("AppId", "Token", true); // 设置机器人信息
OpenApiOptions options = new OpenApiOptions(botInfo)  // 设置OpenApi
    .UseRetry(); // 启用重试功能
ISessionManager sessionManager = new LocalSessionManager(botInfo, options); // 创建一个本地会话管理器
sessionManager.EventBus.ATMessageEvent += MessageEvent; // 直接注册一个事件 (@消息)
await sessionManager.StartAndWait(); // 阻塞在此处启动 (会自动计算Intents)

// 消息事件处理器
static async ValueTask MessageEvent(ATMessageEvent message)
{
    // 用于回复消息
    var msg = new MessageBody()
        .Text("你在")
        .Segment(new ChannelSegment(message.Message.ChannelID))
        .Text("发送的纯文本为:" + message.Context.GetText())
        .EndLine()
        .Emoji(EmojiType.WoofWoof, EmojiType.Moe)
        .Segment(Segment.Emoji(4));
    await message.Context.ReplyMessageAsync(msg); // 引用并回复消息
}
```

### 完整的代码

```csharp
using QQChannelSharp;
using QQChannelSharp.Example.Handlers;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Logger;
using QQChannelSharp.OpenApi;
using QQChannelSharp.Sessions;

Log.Configuration
	.EnableConsoleOutput() // 启用控制台输出 (默认开启)
    .SetLogLevel(LogLevel.Info); // 设置日志输出等级 (默认Info)

ChannelBotInfo botInfo = new("AppId", "Token", true); // 设置机器人信息
OpenApiOptions options = new OpenApiOptions(botInfo)  // 设置OpenApi
    .UseRetry(); // 启用重试功能
ISessionManager sessionManager = new LocalSessionManager(botInfo, options); // 创建一个本地会话管理器
sessionManager.EventBus.ATMessageEvent += MessageEvent; // 直接注册一个事件 (@消息)
await sessionManager.StartAndWait(); // 阻塞在此处启动 (会自动计算Intents)

// 消息事件处理器
static async ValueTask MessageEvent(ATMessageEvent message)
{
    // 用于回复消息
    var msg = new MessageBody()
        .Text("你在")
        .Segment(new ChannelSegment(message.Message.ChannelID))
        .Text("发送的纯文本为:" + message.Context.GetText())
        .EndLine()
        .Emoji(EmojiType.WoofWoof, EmojiType.Moe)
        .Segment(Segment.Emoji(4));
    await message.Context.ReplyMessageAsync(msg); // 引用并回复消息
}
```

### 效果

![img](https://cdn.nlark.com/yuque/0/2023/png/34859559/1678110705716-8a07f450-d468-41fc-9667-2097b35a8620.png)
