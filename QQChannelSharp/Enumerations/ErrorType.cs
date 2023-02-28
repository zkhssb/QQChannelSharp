namespace QQChannelSharp.Enumerations
{
    /// <summary>
    /// 错误类型
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// 鉴权或重连时的错误
        /// </summary>
        InvalidSession,
        /// <summary>
        /// WebSocket的错误
        /// </summary>
        WebSocketError
    }
}
