using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQGuildBotFunc.Dto.Pager
{
    /// <summary>
    /// GuildMembersPager 分页器
    /// </summary>
    public class GuildMembersPager
    {
        /// <summary>
        /// 读此id之后的数据，如果是第一次请求填0，默认为0
        /// </summary>
        [JsonPropertyName("after")]
        public string After { get; set; } = "0";

        /// <summary>
        /// 分页大小，1-1000，默认是1
        /// </summary>
        [JsonPropertyName("limit")]
        public string Limit { get; [Obsolete] set; } = "1";

        /// <summary>
        /// 读此id之后的数据，如果是第一次请求填0，默认为0
        /// </summary>
        public GuildMembersPager WithAfter(string after)
        {
            After = after;
            return this;
        }
        /// <summary>
        /// 分页大小，1-1000，默认是1
        /// </summary>
        public GuildMembersPager WithLimit(int limit = 1)
        {
            if (limit is > 1000 or < 1)
                throw new ArgumentException("分页大小范围是 1-1000");
#pragma warning disable CS0612 // 类型或成员已过时
            Limit = limit.ToString();
#pragma warning restore CS0612 // 类型或成员已过时
            return this;
        }
        /// <summary>
        /// 到Http请求的参数字典
        /// </summary>
        public Dictionary<string, string> QueryParams()
        {
            var query = new Dictionary<string, string>();
            if (Limit != null)
            {
                query.Add("limit", Limit);
            }
            if (After != null)
            {
                query.Add("after", After);
            }
            return query;
        }
    }
}
