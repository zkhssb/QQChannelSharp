using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Mute;
using QQChannelSharp.Dto.Roles;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Interfaces.OpenApi;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class MemberApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;

        [TestMethod]
        public async Task MemberAddRoleAsync()
        {
            var result = await _openApi.MemberAddRoleAsync("0", "1", "2", new()
            {
                Channel = new()
            });
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task MemberDeleteRoleAsync()
        {
            var result = await _openApi.MemberDeleteRoleAsync("0", "1", "2", new()
            {
                Channel = new()
            });
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task MemberMuteAsync()
        {
            var result = await _openApi.MemberMuteAsync("0", "1", new());
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task MultiMemberMuteAsync()
        {
            var result = await _openApi.MultiMemberMuteAsync("0", new());
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}