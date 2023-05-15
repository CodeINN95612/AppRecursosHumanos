﻿using Newtonsoft.Json;

namespace RecursosHumanos.Api.DTO.Ecuasol;

public class EcuasolMovimientoExcepcion
{
    [JsonProperty("DesripMovimientoExce")]
    public string Codigo { get; set; } = string.Empty;

    [JsonProperty("CodigoMovimientoExce")]
    public string Nombre { get; set; } = string.Empty;
}
