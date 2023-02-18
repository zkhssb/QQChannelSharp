using QQGuildBotFunc.Dto.WebSocket;

namespace QQGuildBotFunc.WebSocket
{
    public interface IWebSocketClient : IDisposable
    {
        /// <summary>
        /// Connect 连接到 wss 地址
        /// </summary>
        void Connect();
        /// <summary>
        /// Identify 鉴权连接
        /// </summary>
        void Identify();
        /// <summary>
        /// Session 拉取 session 信息，包括 token，shard，seq 等
        /// </summary>
        Session Session();
        /// <summary>
        /// Resume 重连
        /// </summary>
        void Resume();
        /// <summary>
        /// Listening 监听websocket事件
        /// </summary>
        int Listening();
        /// <summary>
        /// Write 发送数据
        /// </summary>
        /// <param name="message"></param>
        void Write(WebSocketPayload payload);
        /// <summary>
        /// Close 关闭连接
        /// </summary>
        void Close();
    }
}