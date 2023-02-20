using QQChannelSharp.Dto.WebSocket;
using System.Text.Json;

namespace QQChannelSharp.Extensions
{
    public static class WebSocketPayloadExtension
    {
        /// <summary>
        /// 获取Payload的data
        /// </summary>
        /// <typeparam name="TData">data类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">payload.Data is <see langword="null"/></exception>
        /// <exception cref="ArgumentException">payload.Data is not <see langword="JsonElement"/></exception>
        public static TData GetData<TData>(this WebSocketPayload payload)
            where TData : WebSocketDataBase
        {
            if (payload.Data is null)
                throw new ArgumentNullException(nameof(payload));
            if (payload.Data is not JsonElement)
                throw new ArgumentException(nameof(payload.Data));
            return JsonSerializer.Deserialize<TData>((JsonElement)payload.Data)!;
        }
        public static WebSocketPayload WithData(this WebSocketPayload payload, object data)
        {
            payload.Data = data;
            return payload;
        }
    }
}
