using Newtonsoft.Json;
using System;

namespace Ali.Helper.Idle
{
    public class HugeNumberSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((HugeNumber)value).ToFloatString(3));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return HugeNumber.Parse((string)reader.Value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(HugeNumber) || objectType == typeof(HugeNumber?);
        }
    }
}