using RestSharp;

namespace QQChannelSharp.Extensions
{
    public static class RestResponseExtension
    {
        public static string GetTraceId(this RestResponse response)
        {
            object? header = response.Headers
                ?.Where(h => h.Name?.ToLower() == "X-Tps-trace-ID".ToLower())
                .FirstOrDefault()?.Value;
            if (null != header && header is string)
                return header.ToString() ?? string.Empty;
            else
                return string.Empty;
        }
    }
}
