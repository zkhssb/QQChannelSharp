using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using QQChannelSharp.Dto.Channels;
using System.Threading.Tasks;

namespace QQChannelSharp.Dto.Roles
{
    /// <summary>
    /// MemberAddRoleBody 增加子频道管理员身份组时附加内容
    /// </summary>
    public class MemberAddRoleBody
    {
        /// <summary>
        /// 子频道对象
        /// </summary>
        [JsonPropertyName("channel")]
        public required Channel Channel { get; set; }
    }
}
