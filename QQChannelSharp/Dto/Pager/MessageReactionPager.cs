namespace QQChannelSharp.Dto.Pager
{
    public class MessageReactionPager
    {
        /// <summary>
        /// 分页游标
        /// </summary>
        public required string Cookie { get; set; }
        /// <summary>
        /// 分页大小，1-1000，默认是20
        /// </summary>
	    public int Limit { get; [Obsolete] set; } = 20;
        /// <summary>
        /// 分页大小，1-100，默认是20
        /// </summary>
        public MessageReactionPager WithLimit(int limit = 20)
        {
            if (limit is > 1000 or < 1)
                throw new ArgumentException("分页大小范围是 1-1000");
#pragma warning disable CS0612 // 类型或成员已过时
            Limit = limit;
#pragma warning restore CS0612 // 类型或成员已过时
            return this;
        }
        public Dictionary<string, string> ToQueryParams()
        {
            var query = new Dictionary<string, string>();
            if (Limit > 0)
            {
                query["limit"] = Limit.ToString();
            }
            if (!string.IsNullOrEmpty(Cookie))
            {
                query["cookie"] = Cookie;
            }
            return query;
        }
    }
}
