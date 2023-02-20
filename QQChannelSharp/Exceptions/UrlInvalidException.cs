using QQChannelSharp.WebSocket;

namespace QQChannelSharp.Exceptions
{
    public class UrlInvalidException : WebSocketExceptionBase
    {
        public UrlInvalidException(Session session) : base(session, "ws ap url is invalid")
        {
        }
    }
}
