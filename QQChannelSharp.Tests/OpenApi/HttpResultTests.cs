using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Tests.OpenApi
{
    [TestClass]
    public class HttpResultTests
    {
        [TestMethod]
        public void HttpResultTest_DataIsNull()
        {
            HttpResult<string> result = new(null, new Dto.OpenApiError() { ErrorCode = 999, Message = "Test" })
            {
                TraceId = Guid.NewGuid().ToString(),
                IsSuccess = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
            Assert.ThrowsException<InvalidOperationException>(() => result.Result);
        }

        [TestMethod]
        public void HttpResultTest_DataIsNotNull()
        {
            HttpResult<string> result = new("Hello World!")
            {
                TraceId = Guid.NewGuid().ToString(),
                IsSuccess = true,
                StatusCode = System.Net.HttpStatusCode.OK
            };
            Assert.ThrowsException<InvalidOperationException>(() => result.Error);
        }
    }
}
