
using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EPosicion
{
    Arquero,
    Defensa,
    Mediocentro,
    Delantero
}