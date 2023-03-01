using QQChannelSharp.Dto;
using System.Net;

namespace QQChannelSharp.OpenApi
{
    public class HttpResult<TData>
        where TData : class
    {
        /// <summary>
        /// 请求成功数据
        /// </summary>
        private readonly TData? _data;

        /// <summary>
        /// 请求错误数据
        /// </summary>
        private readonly OpenApiError? _error;

        public HttpResult(TData? data = null, OpenApiError? error = null)
        {
            _data = data;
            _error = error;
        }

        /// <summary>
        /// HTTP状态码
        /// </summary>
        public required HttpStatusCode StatusCode { get; init; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public required bool IsSuccess { get; init; }

        /// <summary>
        /// 本次请求追溯ID
        /// </summary>
        public required string TraceId { get; init; }

        /// <summary>
        /// 获取<see langword="Data"/>
        /// <br/>
        /// 但当IsSuccess是False或Data是Null时会抛出<see cref="InvalidOperationException"/>
        /// </summary>
        public TData Result
        {
            get
            {
                if (!IsSuccess || null == _data)
                    throw new InvalidOperationException();
                return _data;
            }
        }

        /// <summary>
        /// 获取<see langword="Error"/>
        /// <br/>
        /// 当Error是null时会抛出<see cref="InvalidOperationException"/>
        /// </summary>
        public OpenApiError Error
        {
            get
            {
                if (null == _error)
                    throw new InvalidOperationException();
                return _error;
            }
        }
    }
}
