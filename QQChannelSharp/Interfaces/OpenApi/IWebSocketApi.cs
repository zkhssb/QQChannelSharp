using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Interfaces.OpenApi
{
    public interface IWebSocketApi
    {
        /// <summary>
        /// 获取带分片的WebSocket接入点信息
        /// </summary>
        /// <returns></returns>
        Task<HttpResult<WebsocketAP>> GetWebSocketApAsync();
    }
}