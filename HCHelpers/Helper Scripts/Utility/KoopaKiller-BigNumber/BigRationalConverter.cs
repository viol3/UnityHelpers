using Koopakiller.Numerics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

public class BigRationalConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var rational = (BigRational)value;
        writer.WriteStartObject();
        writer.WritePropertyName("rationalValue");
        serializer.Serialize(writer, rational.ToDecimalString(2));
        writer.WriteEndObject();
    }

    public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
    {
        JObject jsonObject = JObject.Load(reader);
        var properties = jsonObject.Properties().ToList();
        return BigRational.Parse(properties[0].Value.ToString(), "0123456789", 10, System.Globalization.CultureInfo.CurrentCulture);
    }

    public override bool CanRead
    {
        get { return true; }
    }

    public override bool CanConvert(System.Type objectType)
    {
        return objectType == typeof(BigRational);
    }
}