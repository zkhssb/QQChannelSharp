using QQChannelSharp.Dto.Direct;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Interfaces.OpenApi;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class DirectMessageApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;

        [TestMethod]
        public async Task CreateDirectMessageAsync()
        {
            var result = await _openApi.CreateDirectMessageAsync(new DirectMessageToCreate()
            {
                RecipientID = "11528069550601428493",
                SourceGuildID = "15408510702836394950",
            });
            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public async Task PostDirectMessageAsync()
        {
            var result = await _openApi.PostDirectMessageAsync(new DirectMessage()
            {
                ChannelID = "0",
                CreateTime = "1",
                GuildID = "2",
            }, new());
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task PostDMSettingGuideAsync()
        {
            var result = await _openApi.PostDMSettingGuideAsync(new DirectMessage()
            {
                ChannelID = "0",
                CreateTime = "1",
                GuildID = "2",
            }, "3");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task RetractDMMessageAsync()
        {
            var result = await _openApi.RetractDMMessageAsync("0", "1", null);
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}