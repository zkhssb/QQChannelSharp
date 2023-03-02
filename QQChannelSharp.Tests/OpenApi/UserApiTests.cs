using QQChannelSharp.Dto;
using QQChannelSharp.Dto.Pager;
using QQChannelSharp.Interfaces;
using QQChannelSharp.Interfaces.OpenApi;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class UserApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;

        [TestMethod]
        public async Task MeAsync()
        {
            var result = await _openApi.MeAsync();
            Assert.IsNotNull(result.Result);
            Console.WriteLine("{0}", result.Result.Username);
        }

        [TestMethod]
        public async Task MeGuildsAsync()
        {
            var pager = new GuildPager()
                .WithLimit(100);
            var result = await _openApi.MeGuildsAsync(pager);
            Assert.IsNotNull(result.Result);
            foreach (var guild in result.Result)
            {
                Console.WriteLine("{0}", guild.Name);
            }
        }
    }
}