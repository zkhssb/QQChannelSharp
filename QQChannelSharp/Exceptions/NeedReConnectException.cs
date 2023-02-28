using QQChannelSharp.WebSocket;

namespace QQChannelSharp.Exceptions
{
    public class NeedReConnectException : WebSocketExceptionBase
    {
        public NeedReConnectException(Session session) : base(session, "need reconnect")
        {
        }
    }
}
