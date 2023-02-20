using QQChannelSharp.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQChannelSharp.Exceptions
{
    public class NeedReConnectException : WebSocketExceptionBase
    {
        public NeedReConnectException(Session session) : base(session, "need reconnect")
        {
        }
    }
}
