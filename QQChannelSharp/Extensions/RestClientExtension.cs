using QQChannelSharp.Dto;
using QQChannelSharp.Logger;
using QQChannelSharp.OpenApi;
using RestSharp;
using System.Text.Json;

namespace QQChannelSharp.Extensions
{
    public static class RestClientExtension
    {
        public static async Task<HttpResult<TResult>> ExecAsync<TResult>(this RestClient client, RestRequest request)
            where TResult : class
        {
            var result = await client.ExecuteAsync(request);

            if (null == result)
                return new(default, new() { ErrorCode = -1, Message = "result is null" })
                {
                    IsSuccess = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    TraceId = string.Empty
                };

            TResult? data;
            OpenApiError? error;

            try
            {
                if (result.IsSuccessStatusCode)
                {
                    if (typeof(TResult) == typeof(EmptyObject))
                        data = null;
                    else
                        data = JsonSerializer.Deserialize<TResult>(result?.Content ?? string.Empty);
                    error = default;
                }
                else
                {
                    data = default;
                    error = JsonSerializer.Deserialize<OpenApiError>(result?.Content ?? string.Empty);
                }
            }
            catch (JsonException ex)
            {
                Log.LogFatal("Json序列化错误", ex.ToString());
                data = default;
                error = new()
                {
                    ErrorCode = -1,
                    Message = ex.Message
                };
            }

            return new(data, error)
            {
                IsSuccess = result!.IsSuccessStatusCode,
                StatusCode = result!.StatusCode,
                TraceId = result!.GetTraceId()
            };
        }
    }
}
