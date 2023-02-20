using QQChannelSharp.WebSocket;

namespace QQChannelSharp.Sessions
{
    public class SessionTask
    {
        public required Session Session { get; init; }
        public required Task Task { get; init; }
        public required CancellationTokenSource CancellationTokenSource { get; init; }
    }
}
