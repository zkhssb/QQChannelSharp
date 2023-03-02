using QQChannelSharp.Dto;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Interfaces.OpenApi;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class InteractionApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;

        [TestMethod]
        public async Task PutInteractionAsync()
        {
            var result = await _openApi.PutInteractionAsync("0", string.Empty);
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}