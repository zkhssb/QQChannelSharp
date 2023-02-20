using QQChannelSharp.WebSocket;

namespace QQChannelSharp.Exceptions
{
    public class WebSocketClosedException : WebSocketExceptionBase
    {
        public int CloseCode { get; private set; }
        public WebSocketClosedException(Session session, int closeCode) : base(session, $"ws closed/code:{closeCode}")
        {
            CloseCode = closeCode;
        }
    }
}
