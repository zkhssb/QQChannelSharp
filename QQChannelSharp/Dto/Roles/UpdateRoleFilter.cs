using System.Text.Json.Serialization;

namespace QQChannelSharp.Dto.Roles
{
    /// <summary>
    /// UpdateRoleFilter 身份组可更改数据，修改的
    /// </summary>
    public class UpdateRoleFilter
    {
        [JsonPropertyName("name")]
        public required uint Name { get; set; }

        [JsonPropertyName("color")]
        public required uint Color { get; set; }

        [JsonPropertyName("hoist")]
        public required uint Hoist { get; set; }
    }
}
