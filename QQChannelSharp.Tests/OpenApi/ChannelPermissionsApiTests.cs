using QQChannelSharp.Dto.ChannelPermissions;
using QQChannelSharp.Interfaces;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class ChannelPermissionsApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;

        [TestMethod]
        public async Task ChannelPermissionsAsync()
        {
            var result = await _openApi.ChannelPermissionsAsync("0", "1");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task ChannelRolesPermissionsAsync()
        {
            var result = await _openApi.ChannelRolesPermissionsAsync("0", "1");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task PutChannelPermissionsAsync()
        {
            var result = await _openApi.PutChannelPermissionsAsync("0", "1", new()
            {
                Add = "2"
            });
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task PutChannelRolesPermissionsAsync()
        {
            var result = await _openApi.PutChannelRolesPermissionsAsync("0", "1", new()
            {
                Add = "2"
            });
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}