using QQChannelSharp.Interfaces;
using QQChannelSharp.WebSocket;

namespace QQChannelSharp.Sessions
{
    public class SessionInfo
    {
        public required Session Session { get; init; }
        public required IWebSocketClient Client { get; init; }
    }
}
