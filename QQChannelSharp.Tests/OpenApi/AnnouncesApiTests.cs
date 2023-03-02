using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Announce;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Interfaces.OpenApi;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class AnnouncesApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;

        [TestMethod]
        public async Task CleanChannelAnnouncesAsync()
        {
            var result = await _openApi.CleanChannelAnnouncesAsync("0");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task CleanGuildAnnouncesAsync()
        {
            var result = await _openApi.CleanGuildAnnouncesAsync("0");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task CreateChannelAnnouncesAsync()
        {
            var result = await _openApi.CreateChannelAnnouncesAsync("0", new GuildAnnouncesToCreate()
            {
                AnnouncesType = 0,
                ChannelID = "0",
                MessageID = "0"
            });
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task CreateGuildAnnouncesAsync()
        {
            var result = await _openApi.CreateGuildAnnouncesAsync("0", new GuildAnnouncesToCreate()
            {
                AnnouncesType = 0,
                ChannelID = "0",
                MessageID = "0"
            });
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task DeleteChannelAnnouncesAsync()
        {
            var result = await _openApi.DeleteChannelAnnouncesAsync("0", "1");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task DeleteGuildAnnouncesAsync()
        {
            var result = await _openApi.DeleteGuildAnnouncesAsync("0", "1");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
