using System.Text.Json;
using System.Text.Json.Serialization;

namespace QQChannelSharp.Converters
{
    /// <summary>
    /// 空文本转换器
    /// 由于.Net6开始的特性, 当一个字符串不在Class中设置任何初始值的时候会被编译器判定为NULL
    /// 从而引发可能为NULL的警告,因此在Class中需要设置string的初始值
    /// 但设置初始值后特性: Json值为Null时不序列化 就不生效了 (就算是string.Empty也不会生效) 所以需要这个转换器
    /// </summary>
    public class EmptyStringConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return reader.GetString() ?? string.Empty;
            }

            return string.Empty;
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            if (value != string.Empty)
            {
                writer.WriteStringValue(value);
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}