using QQChannelSharp.Backoffs;
using QQChannelSharp.OpenApi.HttpHandler;
using RestSharp;

namespace QQChannelSharp.Tests
{
    [TestClass]
    public class RestClientErrorTests
    {
        [TestMethod]
        public void RestClientError()
        {
            var opts = new RestClientOptions()
            {
                ThrowOnAnyError = true,
                BaseUrl = new Uri("http://localhost:5196/"),
            };
            HttpClient client = new(new PolicyHttpMessageHandler(DecorrelatedJitterBackoffV2.GetRetryIntervals(3, TimeSpan.FromSeconds(1)), new LoggerHttpHandler()));
            client.BaseAddress = new Uri("http://localhost:5196/");
            RestClient rest = new(client, opts);
            Assert.ThrowsException<HttpRequestException>(() =>
            {
                rest.Execute(new RestRequest("/RestApiTest/ErrorTest"), Method.Put);
            });
        }

        [TestMethod]
        public void RestClientOk()
        {
            var opts = new RestClientOptions()
            {
                ThrowOnAnyError = true,
                BaseUrl = new Uri("http://localhost:5196/"),
            };
            HttpClient client = new(new PolicyHttpMessageHandler(DecorrelatedJitterBackoffV2.GetRetryIntervals(3, TimeSpan.FromSeconds(1)), new LoggerHttpHandler()));
            client.BaseAddress = new Uri("http://localhost:5196/");
            RestClient rest = new(client, opts);
            rest.Execute(new RestRequest("/RestApiTest/ErrorTest"), Method.Get);
        }
    }
}