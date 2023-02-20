using Microsoft.Extensions.Http;
using Polly;
using Polly.Contrib.WaitAndRetry;
using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.Interfaces;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using System.Linq.Expressions;
using System.Net;

namespace QQChannelSharp.OpenApi
{
    public sealed class OpenApi : IOpenApi, IDisposable
    {
        /// <summary>
        /// 机器人Token
        /// </summary>
        public string Token { get; private set; } // Bot xxx
        /// <summary>
        /// 沙盒模式
        /// </summary>
        public bool SandBox
        {
            get => _sandBox;
            set
            {
                _client.Options.BaseUrl = new Uri(value ? "https://sandbox.api.sgroup.qq.com" : "https://api.sgroup.qq.com/");
                _sandBox = value;
            }
        }

        /// <summary>
        /// 重试次数
        /// </summary>
        private int RetryCount;
        /// <summary>
        /// 重试间隔
        /// </summary>
        private TimeSpan RetryInterval;

        private bool _sandBox;
        private RestClient _client;
        private HttpClient _httpClient;
        private IAsyncPolicy<HttpResponseMessage>? _retryPolicy;
        private IEnumerable<TimeSpan> DecorrelatedJitterBackoffV2()
            => Backoff.DecorrelatedJitterBackoffV2(RetryInterval, RetryCount);

        /// <param name="token">机器人Token,通常是:<c>{appId}.{appToken}</c></param>
        /// <param name="sandBox">沙盒模式</param>
        public OpenApi(string token, bool sandBox = false)
        {
            Token = token;
            _sandBox = sandBox;
            _httpClient = new();
            _client = new RestClient(_httpClient, GetRestClientOptions())
                .UseAuthenticator(new OAuth2AuthorizationRequestHeaderAuthenticator(Token, "Bot"));
        }

        /// <summary>
        /// 使用Polly (默认策略)
        /// 遇遇到Http错误、408、大于500的状态码时重发
        /// </summary>
        /// <param name="retryCount">最大重试次数</param>
        /// <param name="retryInterval">间隔(单位秒)</param>
        /// <returns></returns>
        public OpenApi UsePolly(int retryCount, int retryInterval)
        {
            RetryCount = retryCount;
            RetryInterval = TimeSpan.FromSeconds(retryInterval);
            UsePolly(Policy<HttpResponseMessage>
                .Handle<HttpRequestException>()
                .Or<TimeoutException>()
                .OrResult(x => x.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
                .WaitAndRetryAsync(DecorrelatedJitterBackoffV2()));
            return this;
        }
        /// <summary>
        /// 使用Polly (默认策略) 
        /// 遇到Http错误、408、大于500的状态码时重发
        /// <br/>
        /// 默认为重试5次间隔一秒
        /// </summary>
        /// <returns></returns>
        public OpenApi UsePolly()
        {
            UsePolly(5, 1);
            return this;
        }
        /// <summary>
        /// 使用自定义 (使用自定义后无法使用 <see cref="RetryCount"/> 和 <see cref="RetryInterval"/> 来获取重试信息)
        /// </summary>
        public OpenApi UsePolly(IAsyncPolicy<HttpResponseMessage> retryPolicy)
        {
            _retryPolicy = retryPolicy;
            _httpClient.Dispose();
            _client.Dispose();
            var handler = new PolicyHttpMessageHandler(_retryPolicy)
            {
                InnerHandler = new HttpClientHandler()
            };
            _httpClient = new(handler);
            _client = new(_httpClient, GetRestClientOptions());
            _client.UseAuthenticator(new OAuth2AuthorizationRequestHeaderAuthenticator(Token, "Bot"));
            return this;
        }

        public string TraceID()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// OpenApi V1
        /// </summary>
        public int Version()
            => 1;
        public void Dispose()
        {
            _httpClient?.Dispose();
            _client?.Dispose();
        }

        public string Me()
        {
            return _client.Get(new RestRequest("/users/@me")).Content ?? string.Empty;
        }

        public WebsocketAP GetAp()
        {
            return _client.Get<WebsocketAP>(new RestRequest("/gateway/bot"))!;
        }

        private RestClientOptions GetRestClientOptions()
        => new()
        {
            BaseUrl = new Uri(_sandBox ? "https://sandbox.api.sgroup.qq.com" : "https://api.sgroup.qq.com/"),
            ThrowOnAnyError = true
        };
    }
}
