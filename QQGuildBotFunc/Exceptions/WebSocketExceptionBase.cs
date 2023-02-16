using QQGuildBotFunc.WebSocket;

namespace QQGuildBotFunc.Exceptions
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
