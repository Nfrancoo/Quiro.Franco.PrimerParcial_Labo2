using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EPaises
{
    Francia,
    Argentina,
    Brasil ,
    Alemania,
    Italia
}