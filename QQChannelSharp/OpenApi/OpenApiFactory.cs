using QQChannelSharp.Backoffs;
using QQChannelSharp.Interfaces;
using QQChannelSharp.OpenApi.HttpHandler;
using RestSharp;
using RestSharp.Authenticators.OAuth2;

namespace QQChannelSharp.OpenApi
{
    public class OpenApiFactory
    {
        /// <summary>
        /// 创建一个OpenApi实例
        /// </summary>
        public static IOpenApi Create(OpenApiOptions options)
        {
            HttpClient httpClient;
            RestClient restClient;
            var opts = new RestClientOptions()
            {
                ThrowOnAnyError = false,
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(options.BotInfo.FullToken, "Bot")
            };
            if (options.Retry)
            {
                /*
                // 使用Polly
                IAsyncPolicy<HttpResponseMessage> retryPolicy = _policy<HttpResponseMessage>
                    .Handle<HttpRequestException>()
                    .Or<TimeoutException>()
                    .OrResult(x => x.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout or HttpStatusCode.GatewayTimeout)
                    .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5));
                */

                var handler = new PolicyHttpMessageHandler(DecorrelatedJitterBackoffV2.GetRetryIntervals(options.RetryCount, options.RetryInterval), new LoggerHttpHandler());
                httpClient = new(handler);
                httpClient.BaseAddress = new Uri(options.BotInfo.SandBox ? "https://sandbox.api.sgroup.qq.com/" : "https://api.sgroup.qq.com/");
                restClient = new(httpClient, opts);
            }
            else
            {
                httpClient = new(new LoggerHttpHandler());
                httpClient.BaseAddress = new Uri(options.BotInfo.SandBox ? "https://sandbox.api.sgroup.qq.com/" : "https://api.sgroup.qq.com/");
                restClient = new(httpClient, opts);
            }
            return new OpenApi(restClient, httpClient);
        }
    }
}
