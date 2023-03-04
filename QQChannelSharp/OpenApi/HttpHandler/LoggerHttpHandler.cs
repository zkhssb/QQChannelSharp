using QQChannelSharp.Logger;

namespace QQChannelSharp.OpenApi.HttpHandler
{
    public class LoggerHttpHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var result = await base.SendAsync(request, cancellationToken);
            string content = string.Empty;
            string traceId = string.Empty;

            if (result.Headers.TryGetValues("X-Tps-trace-ID", out var value))
            {
                traceId = value.FirstOrDefault() ?? string.Empty;
            }

            if (result.Content != null)
                content = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
                Log.LogInfo("http", $"[{request.Method}/{result.StatusCode}]{request.RequestUri?.PathAndQuery} TraceID: {traceId}");
            else
                Log.LogError("http", $"[{request.Method}/{result.StatusCode}]{request.RequestUri?.PathAndQuery} TraceID:{traceId} {content}");
            return result;
        }
    }
}