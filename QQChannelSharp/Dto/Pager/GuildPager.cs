using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Pager
{
    /// <summary>
    /// GuildPager 分页器
    /// </summary>
    public class GuildPager
    {
        /// <summary>
        /// 读此id之前的数据
        /// </summary>
        [JsonPropertyName("before")]
        public string Before { get; set; } = "0";

        /// <summary>
        /// 读此id之后的数据
        /// </summary>
        [JsonPropertyName("after")]
        public string After { get; set; } = "0";

        /// <summary>
        /// 分页大小，1-100，默认是10
        /// </summary>
        [JsonPropertyName("limit")]
        public string Limit { get; [Obsolete] set; } = "100";

        /// <summary>
        /// 读此id之后的数据
        /// </summary>
        public GuildPager WithAfter(string after)
        {
            After = after;
            return this;
        }
        /// <summary>
        /// 读此id之前的数据
        /// </summary>
        public GuildPager WithBefore(string before)
        {
            Before = before;
            return this;
        }
        /// <summary>
        /// 分页大小，1-100，默认是100
        /// </summary>
        public GuildPager WithLimit(int limit = 100)
        {
            if (limit is > 100 or < 1)
                throw new ArgumentException("分页大小范围是 1-1000");
#pragma warning disable CS0612 // 类型或成员已过时
            Limit = limit.ToString();
#pragma warning restore CS0612 // 类型或成员已过时
            return this;
        }
        public Dictionary<string, string> QueryParams()
        {
            var query = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(Limit))
            {
                query.Add("limit", Limit);
            }
            if (!string.IsNullOrEmpty(After))
            {
                query.Add("after", After);
            }
            // 优先 after
            if (string.IsNullOrEmpty(After) && !string.IsNullOrEmpty(Before))
            {
                query.Add("before", Before);
            }
            return query;
        }
    }
}
