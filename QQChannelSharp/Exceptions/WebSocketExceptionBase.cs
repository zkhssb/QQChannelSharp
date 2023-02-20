using QQChannelSharp.WebSocket;

namespace QQChannelSharp.Exceptions
{
    public abstract class WebSocketExceptionBase : Exception
    {
        protected Session Session { get; private set; }
        protected WebSocketExceptionBase(Session session, string? message = null) : base(message)
        {
            Session = session;
        }
    }
}
