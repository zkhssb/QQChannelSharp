using RestSharp;

namespace QQChannelSharp.Extensions
{
    public static class RestResponseExtension
    {
        public static string GetTraceId(this RestResponse response)
            => response.Headers
                ?.Where(h => h.Name?.ToLower() == "X-Tps-trace-ID".ToLower())
                .FirstOrDefault()?.Value?.ToString() ?? string.Empty;
    }
}
