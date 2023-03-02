using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Message;
using QQChannelSharp.Dto.Messages;
using QQChannelSharp.Dto.Pager;
using QQChannelSharp.Enumerations;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Interfaces.OpenApi;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class MessageApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;

        [TestMethod]
        public async Task MessageAsync()
        {
            var result = await _openApi.MessageAsync("2337235", "08c6d7f8828bdb81ebd50110d3d38e01388d0448c8f6ff9f06");
            Assert.IsNotNull(result.Result);
            Console.WriteLine("消息: {0}", result.Result.Message.Content);
        }

        [TestMethod]
        public async Task MessagesAsync()
        {
            var result = await _openApi.MessagesAsync("2337235", new()
            {
                ID = "08c6d7f8828bdb81ebd50110d3d38e01388d0448c8f6ff9f06",
                Limit = 5,
                Type = MessagePagerType.Before
            });
            Assert.IsTrue(result.Error.ErrorCode == 11253); //check app privilege not pass
        }

        [TestMethod]
        public async Task PatchMessageAsync()
        {
            var result = await _openApi.PatchMessageAsync("0", "1", new());
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task PostMessageAsync()
        {
            var result = await _openApi.PostMessageAsync("0", new());
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task PostSettingGuideAsync()
        {
            var result = await _openApi.PostSettingGuideAsync("0", new string[1]
            {
                "1"
            });
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task RetractMessageAsync()
        {
            var result = await _openApi.RetractMessageAsync("0", "1", null);
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}