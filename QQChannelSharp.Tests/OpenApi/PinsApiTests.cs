using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Messages;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Interfaces.OpenApi;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class PinsApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;

        [TestMethod]
        public async Task GetPinsAsync()
        {
            await AddPinsAsync();
            var result = await _openApi.GetPinsAsync("2337235");
            await CleanPinsAsync();
            Assert.IsTrue(result.IsSuccess);
            foreach (var pinMessage in result.Result.MessageIDs)
            {
                Console.WriteLine("精华消息: {0}", (await _openApi.MessageAsync("2337235", pinMessage)).Result.Message.Content);
            }
        }


        [TestMethod]
        public async Task AddPinsAsync()
        {
            await CleanPinsAsync();
            var result = await _openApi.AddPinsAsync("2337235", "08c6d7f8828bdb81ebd50110d3d38e01388d0448c8f6ff9f06");
            Assert.IsNotNull(result.Result);
        }

        [TestMethod]
        public async Task CleanPinsAsync()
        {
            var result = await _openApi.CleanPinsAsync("2337235");
            Assert.IsTrue(result.IsSuccess);
        }

        [TestMethod]
        public async Task DeletePinsAsync()
        {
            var result = await _openApi.DeletePinsAsync("0", "1");
            Assert.IsNotNull(result.Error);
        }
    }
}