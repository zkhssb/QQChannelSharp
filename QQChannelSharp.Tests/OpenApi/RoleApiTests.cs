using QQChannelSharp.Dto.Roles;
using QQChannelSharp.Interfaces;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class RoleApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;
        [TestMethod]
        public async Task DeleteRoleAsync()
        {
            var result = await _openApi.DeleteRoleAsync("0", "1");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task GetRolesAsync()
        {
            var result = await _openApi.GetRolesAsync("15408510702836394950");
            Assert.IsNotNull(result.Result);
            foreach (var role in result.Result.Roles)
            {
                Console.WriteLine("{0}/Role: {1}", role.ID, role.Name);
            }
        }

        [TestMethod]
        public async Task PatchRoleAsync()
        {
            var result = await _openApi.PatchRoleAsync("0", "1", new Role());
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task PostRoleAsync()
        {
            var result = await _openApi.PostRoleAsync("0", new Role());
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}