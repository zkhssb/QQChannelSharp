using QQChannelSharp.Interfaces;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class APIPermissionsApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;

        [TestMethod]
        public async Task GetPermissionAsync()
        {
            var result = await _openApi.GetPermissionAsync("0");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task RequireAPIPermissionsAsync()
        {
            var result = await _openApi.RequireAPIPermissionsAsync("0", new()
            {
                ChannelID = "0",
                Desc = "API单元测试"
            });
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}
