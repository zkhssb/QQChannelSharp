using QQChannelSharp;
using QQChannelSharp.Example.Handlers;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Logger;
using QQChannelSharp.OpenApi;
using QQChannelSharp.Sessions;

Log.Configuration
    .EnableConsoleOutput()
    .SetLogLevel(LogLevel.Info);

ChannelBotInfo botInfo = new("appId", "token", false);
OpenApiOptions options = new OpenApiOptions(botInfo)
    .UseRetry();
ISessionManager sessionManager = new LocalSessionManager(botInfo, options);
sessionManager.EventBus.Subscribe(new BotEventHandler());
await sessionManager.StartAndWait();