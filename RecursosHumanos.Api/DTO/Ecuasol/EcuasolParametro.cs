using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace RecursosHumanos.Api.DTO.Ecuasol;

public class EcuasolParametro
{
    [JsonProperty("Descripcion")]
    public string Codigo { get; set; } = string.Empty;

    [JsonProperty("Codigo")]
    public string Nombre { get; set; } = string.Empty;
}
