using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Members;
using QQChannelSharp.Dto.Mute;
using QQChannelSharp.Dto.Options;
using QQChannelSharp.Dto.Pager;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Interfaces.OpenApi;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class GuildApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;
        [TestMethod]
        public async Task DeleteGuildMemberAsync()
        {
            var result = await _openApi.DeleteGuildMemberAsync("0", "1", null);
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task GetGuildAsync()
        {
            var result = await _openApi.GetGuildAsync("15408510702836394950");
            Assert.IsNotNull(result.Result);
            Console.WriteLine("频道名: {0}", result.Result.Name);
        }

        [TestMethod]
        public async Task GetGuildMemberAsync()
        {
            var result = await _openApi.GetGuildMemberAsync("15408510702836394950", "11528069550601428493");
            Assert.IsNotNull(result.Result);
            Console.WriteLine("用户名: {0}\n加入频道时间:{1}", result.Result.User?.Username, result.Result.JoinedAt);
        }

        [TestMethod]
        public async Task GetGuildMembersAsync()
        {
            var result = await _openApi.GetGuildMembersAsync("15408510702836394950", new GuildMembersPager().WithLimit(100));
            Assert.IsNotNull(result.Result);
            Console.WriteLine("拉到的用户数: {0}", result.Result.Count);
        }

        [TestMethod]
        public async Task GuildMuteAsync()
        {
            var result = await _openApi.GuildMuteAsync("0", new());
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}