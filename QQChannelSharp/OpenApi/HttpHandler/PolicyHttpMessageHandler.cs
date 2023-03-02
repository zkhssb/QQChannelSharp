using System.Net;

namespace QQChannelSharp.OpenApi.HttpHandler
{
    /// <summary>
    /// 策略HttpHandler (重试策略)
    /// </summary>
    public class PolicyHttpMessageHandler : DelegatingHandler
    {
        private readonly TimeSpan[] _policy;

        /// <param name="policy">重试时间策略</param>
        public PolicyHttpMessageHandler(IEnumerable<TimeSpan> policy)
        {
            _policy = policy
                .ToArray().Reverse()
                .Append(TimeSpan.FromSeconds(0))
                .Reverse().ToArray();
        }

        /// <param name="policy">重试时间策略</param>
        public PolicyHttpMessageHandler(IEnumerable<TimeSpan> policy, HttpClientHandler handler) : base(handler)
        {
            _policy = policy
                .ToArray().Reverse()
                .Append(TimeSpan.FromSeconds(0))
                .Reverse().ToArray();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            foreach (var policy in _policy)
            {
                await Task.Delay(policy, cancellationToken);
                HttpResponseMessage? result = null;
                try
                {
                    result = await base.SendAsync(request, cancellationToken);
                }
                catch (HttpRequestException) { }
                if (!(result != null && result.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout or HttpStatusCode.GatewayTimeout))
                {
                    return result!;
                }
                else
                {
                    result?.Dispose();
                }
            }
            throw new HttpRequestException("All retries failed.");
        }
    }
}