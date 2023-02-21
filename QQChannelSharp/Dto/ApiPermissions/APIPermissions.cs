﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQChannelSharp.Dto.ApiPermissions
{
    /// <summary>
    /// APIPermissions API 权限列表对象
    /// </summary>
    public class APIPermissions
    {
        /// <summary>
        /// API 权限列表
        /// </summary>
        [JsonPropertyName("apis")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public required APIPermission[] Apis { get; set; }
    }
}