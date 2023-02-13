using QQGuildBotFunc.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQGuildBotFunc.Dto.Pager
{
    /// <summary>
    /// 消息分页
    /// </summary>
    public class MessagesPager
    {
        /// <summary>
        /// 拉取类型
        /// </summary>
        public required MessagePagerType Type { get; set; }
        /// <summary>
        /// 消息ID
        /// </summary>
        public required string ID { get; set; }
        /// <summary>
        /// 拉取数量,最大 20
        /// </summary>
        public required int Limit { get; set; } = 1;
        public Dictionary<string, string> QueryParams()
        {
            var query = new Dictionary<string, string>();
            if (Limit > 0)
            {
                query["limit"] = Limit.ToString();
            }
            if (Type != 0 && !string.IsNullOrEmpty(ID))
            {
                query[Type.ToString().ToLower()] = ID;
            }
            return query;
        }
    }
}
