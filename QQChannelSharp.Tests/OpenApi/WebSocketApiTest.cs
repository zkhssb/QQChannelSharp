using QQChannelSharp.Dto.WebSocket;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Interfaces.OpenApi;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class WebSocketApiTest
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;
        [TestMethod]
        public async Task GetWebSocketApAsync()
        {
            var result = await _openApi.GetWebSocketApAsync();
            Assert.IsNotNull(result.Result);
            Console.WriteLine("接入点:{0}\n建议分片数:{1}", result.Result.Url, result.Result.Shards);
        }
    }
}