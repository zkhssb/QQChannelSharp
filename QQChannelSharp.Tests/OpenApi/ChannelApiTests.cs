using QQChannelSharp.Dto.Channels;
using QQChannelSharp.Interfaces;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class ChannelApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;
        [TestMethod]
        public async Task CreatePrivateChannelAsync()
        {
            var result = await _openApi.CreatePrivateChannelAsync("0", new ChannelValueObject(), new string[1]
            {
                "1"
            });
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task DeleteChannelAsync()
        {
            var result = await _openApi.DeleteChannelAsync("0");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task GetChannelAsync()
        {
            var result = await _openApi.GetChannelAsync("0");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task GetChannelsAsync()
        {
            var result = await _openApi.GetChannelsAsync("0");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task ListVoiceChannelMembersAsync()
        {
            var result = await _openApi.ListVoiceChannelMembersAsync("0");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task PatchChannelAsync()
        {
            var result = await _openApi.PatchChannelAsync("0", new());
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task PostChannelAsync()
        {
            var result = await _openApi.PostChannelAsync("0", new());
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}