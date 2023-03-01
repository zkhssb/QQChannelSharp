using Microsoft.Extensions.Logging;
using QQChannelSharp.Utils;

namespace QQChannelSharp.OpenApi.HttpHandler
{
    public class LoggerHttpHandler : HttpClientHandler
    {
        private readonly ILogger<LoggerHttpHandler> _logger;
        public LoggerHttpHandler()
        {
            _logger = LoggerUtils.CreateLogger<LoggerHttpHandler>();
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var result = await base.SendAsync(request, cancellationToken);
            string content = string.Empty;
            string traceId = result.Headers.GetValues("X-Tps-trace-ID").FirstOrDefault() ?? string.Empty;
            if (result.Content != null)
                content = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
                _logger.LogInformation("[{0}/{1}]{2} TraceID: {3}", request.Method, result.StatusCode.ToString(), request.RequestUri?.PathAndQuery, traceId);
            else
                _logger.LogError("[{0}/{1}]{2} TraceID:{3} {4}", request.Method, result.StatusCode.ToString(), request.RequestUri?.PathAndQuery, traceId, content);
            return result;
        }
    }
}