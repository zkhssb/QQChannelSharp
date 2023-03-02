using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Messages;
using QQChannelSharp.Dto.Pager;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Interfaces.OpenApi;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class MessageReactionApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;

        [TestMethod]
        [Priority(2)]
        public async Task CreateMessageReactionAsync()
        {
            var result = await _openApi.CreateMessageReactionAsync("2337235", "08c6d7f8828bdb81ebd50110d3d38e01388d0448c8f6ff9f06", new Emoji()
            {
                ID = "4",
                Type = 1,
            });
            Assert.IsTrue(result.IsSuccess || result.Error.ErrorCode == 620003); // 620003 = already had reaction
        }

        [TestMethod]
        [Priority(1)]
        public async Task DeleteOwnMessageReaction()
        {
            var result = await _openApi.DeleteOwnMessageReaction("2337235", "08c6d7f8828bdb81ebd50110d3d38e01388d0448c8f6ff9f06", new Emoji()
            {
                ID = "4",
                Type = 1,
            });
            Assert.IsTrue(result.IsSuccess || result.Error.ErrorCode == 620004); // 620004 = reaction not exists
        }

        [TestMethod]
        public async Task GetMessageReactionUsersAsync()
        {
            var result = await _openApi.GetMessageReactionUsersAsync("0", "1", new Emoji()
            {
                ID = "4",
                Type = 1,
            }, new() { Cookie = "0" });
            Assert.IsTrue(!result.IsSuccess);
        }
    }
}