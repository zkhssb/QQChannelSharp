using QQGuildBotFunc.WebSocket;

namespace QQGuildBotFunc.Exceptions
{
    public class UrlInvalidException : WebSocketExceptionBase
    {
        public UrlInvalidException(Session session) : base(session, "ws ap url is invalid")
        {
        }
    }
}
