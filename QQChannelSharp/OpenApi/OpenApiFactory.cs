using Polly.Contrib.WaitAndRetry;
using Polly;
using QQChannelSharp.Interfaces;
using QQChannelSharp.OpenApi.HttpHandler;
using RestSharp;
using System.Net;
using Microsoft.Extensions.Http;
using RestSharp.Authenticators.OAuth2;

namespace QQChannelSharp.OpenApi
{
    public class OpenApiFactory
    {
        /// <summary>
        /// 创建一个OpenApi实例
        /// </summary>
        public static IOpenApi Create(OpenApiFactoryOptions options)
        {
            HttpClient httpClient;
            RestClient restClient;
            if (options.Polly)
            {
                // 使用Polly
                IAsyncPolicy<HttpResponseMessage> retryPolicy = Policy<HttpResponseMessage>
                    .Handle<HttpRequestException>()
                    .Or<TimeoutException>()
                    .OrResult(x => x.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout or HttpStatusCode.GatewayTimeout)
                    .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5));
                var opts = new RestClientOptions()
                {
                    BaseUrl = new Uri(options.BotInfo.SandBox ? "https://sandbox.api.sgroup.qq.com/" : "https://api.sgroup.qq.com/"),
                    ThrowOnAnyError = true
                };
                var handler = new PolicyHttpMessageHandler(retryPolicy)
                {
                    InnerHandler = new LoggerHttpHandler()
                };
                httpClient = new(handler);
                restClient = new(httpClient);
            }
            else
            {
                httpClient = new(new LoggerHttpHandler());
                restClient = new(httpClient);
            }
            // 添加验证Header "Bot {appId}.{token}"
            restClient.UseAuthenticator(new OAuth2AuthorizationRequestHeaderAuthenticator(options.BotInfo.FullToken, "Bot"));
            return new OpenApi(restClient, httpClient, options.BotInfo);
        }
    }
}
