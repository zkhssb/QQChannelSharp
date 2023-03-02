using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Audio;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Interfaces.OpenApi;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class AudioApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;
        [TestMethod]
        public async Task PostAudioAsync()
        {
            var result = await _openApi.PostAudioAsync("0", new AudioControl()
            {
                Text = "API单元测试",
                URL = ""
            });
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}