﻿using QQChannelSharp.Dto;
using QQChannelSharp.OpenApi;

namespace QQChannelSharp.Interfaces.OpenApi
{
    /// <summary>
    /// 互动接口
    /// </summary>
    public interface IInteractionApi
    {
        /// <summary>
        /// 更新互动信息
        /// </summary>
        /// <param name="interactionId">互动ID</param>
        /// <param name="body"></param>
        /// <returns></returns>
        Task<HttpResult<EmptyObject>> PutInteractionAsync(string interactionId, string body);
    }
}
