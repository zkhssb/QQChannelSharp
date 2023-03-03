using QQChannelSharp.Converters;
using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.Enumerations;
using System.Text.Json;

namespace QQChannelSharp.Extensions
{
    public static class WebSocketPayloadExtension
    {
        private static readonly JsonSerializerOptions _options;
        static WebSocketPayloadExtension()
        {
            _options = new();
            _options.Converters.Add(new EmptyStringConverter());
        }

        /// <summary>
        /// 获取Payload的data
        /// </summary>
        /// <typeparam name="TData">data类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">payload.Data is <see langword="null"/></exception>
        /// <exception cref="ArgumentException">payload.Data is not <see langword="JsonElement"/></exception>
        public static TData GetData<TData>(this WebSocketPayload payload)
        {
            if (payload.Data is null)
                throw new ArgumentNullException(nameof(payload));
            if (payload.Data is not JsonElement)
                throw new ArgumentException(nameof(payload.Data));
            return JsonSerializer.Deserialize<TData>((JsonElement)payload.Data, _options)!;
        }
        public static WebSocketPayload WithData(this WebSocketPayload payload, object data)
        {
            payload.Data = data;
            return payload;
        }
        /// <summary>
        /// 获取事件类型
        /// </summary>
        public static EventType GetEventType(this WebSocketPayload payload)
        {
            Enum.TryParse(typeof(EventType), payload.EventType, true, out var eventType);
            return (EventType)(eventType ?? EventType.Unknown);
        }
    }
}
