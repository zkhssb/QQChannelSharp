using QQChannelSharp.Converters;
using RestSharp;
using System.Text.Json;

namespace QQChannelSharp.Extensions
{
    public static class RestRequestExtension
    {
        private static readonly JsonSerializerOptions _options;
        static RestRequestExtension()
        {
            _options = new();
            _options.Converters.Add(new EmptyStringConverter());
        }
        public static RestRequest AddQueryParameter(this RestRequest request, Dictionary<string, string> pairs)
        {
            foreach (var pair in pairs)
            {
                request.AddQueryParameter(pair.Key, pair.Value);
            }
            return request;
        }
        public static RestRequest AddDto<T>(this RestRequest request, T body)
        {
            string bodyString = JsonSerializer.Serialize(body, _options);
            request.AddBody(bodyString, "application/json");
            return request;
        }
    }
}
