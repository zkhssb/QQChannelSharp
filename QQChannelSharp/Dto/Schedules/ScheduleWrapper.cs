using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QQChannelSharp.Dto.Schedules
{
    /// <summary>
    /// ScheduleWrapper 创建、修改日程的中间对象
    /// </summary>
    public class ScheduleWrapper
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("schedule")]
        public Schedule? Schedule { get; set; }
    }
}
