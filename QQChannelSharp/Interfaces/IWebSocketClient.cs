using QQChannelSharp.Dto.WebSocket;
using System.Net.WebSockets;

namespace QQChannelSharp.WebSocket
{
    /// <summary>
    /// WebSocket连接关闭异步回调
    /// </summary>
    public delegate Task WebSocketClosedAsyncCallBack(Session session, int closeCode, string message);
    public delegate Task WebSocketErrorAsyncCallBack(Session session, WebSocketException error);
    public delegate Task PayloadReceivedAsyncCallBack(Session session, WebSocketPayload payload);
    public interface IWebSocketClient : IDisposable
    {
        event WebSocketClosedAsyncCallBack ClientClosed;
        event PayloadReceivedAsyncCallBack Received;
        event WebSocketErrorAsyncCallBack Error;
        /// <summary>
        /// Connect 连接到 wss 地址
        /// </summary>
        Task ConnectAsync();
        /// <summary>
        /// Identify 鉴权连接
        /// </summary>
        Task IdentifyAsync();
        /// <summary>
        /// Session 拉取 session 信息，包括 token，shard，seq 等
        /// </summary>
        Session Session();
        /// <summary>
        /// Resume 重连
        /// </summary>
        Task ResumeAsync();
        /// <summary>
        /// Listening 监听websocket事件
        /// </summary>
        Task StartListeningAsync();
        /// <summary>
        /// Write 发送数据
        /// </summary>
        /// <param name="message"></param>
        Task WriteAsync(WebSocketPayload payload);
        /// <summary>
        /// Close 关闭连接
        /// </summary>
        void Close();
    }
}