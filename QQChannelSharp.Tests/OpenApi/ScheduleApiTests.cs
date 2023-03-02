using QQChannelSharp.Dto.Schedules;
using QQChannelSharp.Interfaces;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class ScheduleApiTests
    {
        private readonly IOpenApi _openApi = OpenApiRes.OpenApi;

        [TestMethod]
        public async Task CreateScheduleAsync()
        {
            var result = await _openApi.CreateScheduleAsync("0", new Schedule());
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task DeleteScheduleAsync()
        {
            var result = await _openApi.DeleteScheduleAsync("0", "1");
            Assert.IsTrue(!result.IsSuccess);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task GetScheduleAsync()
        {
            var result = await _openApi.GetScheduleAsync("0", "1");
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task ListSchedulesAsync()
        {
            var result = await _openApi.ListSchedulesAsync("0", 0);
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task ModifyScheduleAsync()
        {
            var result = await _openApi.ModifyScheduleAsync("0", "0", new());
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.Unauthorized);
        }
    }
}