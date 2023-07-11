
using Newtonsoft.Json;

namespace RecursosHumanos.Api.DTO.Ecuasol;

public class EcuasolTrabajador
{
    [JsonProperty("COMP_Codigo")]
    public int? CodigoSucursal { get; set; }

    [JsonProperty("Id_Trabajador")]
    public int? Id { get; set; }

    [JsonProperty("Tipo_trabajador")]
    public string? TipoTrabajador { get; set; } = string.Empty;

    [JsonProperty("Apellido_Paterno")]
    public string? ApellidoPaterno { get; set; } = string.Empty;

    [JsonProperty("Apellido_Materno")]
    public string? ApellidoMaterno { get; set; } = string.Empty;

    [JsonProperty("Nombres")]
    public string? Nombres { get; set; } = string.Empty;

    [JsonProperty("Identificacion")]
    public string? Identificacion { get; set; } = string.Empty;

    [JsonProperty("Entidad_Bancaria")]
    public string? EntidadBancaria { get; set; } = string.Empty;

    [JsonProperty("CarnetIESS")]
    public string? CarnetIESS { get; set; } = "N/A";

    [JsonProperty("Direccion")]
    public string? Direccion { get; set; } = string.Empty;

    [JsonProperty("Telefono_Fijo")]
    public string? TelefonoFijo { get; set; } = string.Empty;

    [JsonProperty("Telefono_Movil")]
    public string? TelefonoMovil { get; set; } = string.Empty;

    [JsonProperty("Genero")]
    public string? Sexo { get; set; } = string.Empty;

    [JsonProperty("Nro_Cuenta_Bancaria")]
    public string? NumeroCuentaBancaria { get; set; } = string.Empty;

    [JsonProperty("Codigo_Categoria_Ocupacion")]
    public string? CargoCategoriaOcupacion { get; set; } = string.Empty;

    [JsonProperty("Ocupacion")]
    public string? Ocupacion { get; set; } = string.Empty;

    [JsonProperty("Centro_Costos")]
    public string? CentroCostos { get; set; } = string.Empty;

    [JsonProperty("Nivel_Salarial")]
    public string? NivelSalarial { get; set; } = string.Empty;

    [JsonProperty("EstadoTrabajador")]
    public string? EstadoTrabajador { get; set; } = string.Empty;

    [JsonProperty("Tipo_Contrato")]
    public string? TipoContrato { get; set; } = string.Empty;

    [JsonProperty("Tipo_Cese")]
    public string? TipoCese { get; set; } = string.Empty;

    [JsonProperty("EstadoCivil")]
    public string? EstadoCivil { get; set; } = string.Empty;

    [JsonProperty("TipodeComision")]
    public string? TipoComision { get; set; } = string.Empty;

    [JsonProperty("FechaNacimiento")]
    public DateTime? FechaNacimiento { get; set; } = DateTime.MinValue;

    [JsonProperty("FechaIngreso")]
    public DateTime? FechaIngreso { get; set; } = DateTime.MinValue;

    [JsonProperty("FechaCese")]
    public DateTime? FechaCese { get; set; } = DateTime.MinValue;

    [JsonProperty("PeriododeVacaciones")]
    public int? PeriodoVacaciones { get; set; }

    [JsonProperty("FechaReingreso")]
    public DateTime? FechaReingreso { get; set; } = DateTime.MinValue;

    [JsonProperty("Fecha_Ult_Actualizacion")]
    public DateTime? FechaUltimaActualizacion { get; set; } = DateTime.MinValue;

    [JsonProperty("EsReingreso")]
    public string? EsReingreso { get; set; } = string.Empty;

    [JsonProperty("BancoCTA_CTE")]
    public int? BancoCTA_CTE { get; set; }

    [JsonProperty("Tipo_Cuenta")]
    public string? TipoCuenta { get; set; } = string.Empty;

    [JsonProperty("RSV_Indem_Acumul")]
    public int? RSVIndemAcumul { get; set; }

    [JsonProperty("Mes_Ult_Rsva_Indemni")]
    public int? Mes_Ult_Rsva_Indemni { get; set; }

    [JsonProperty("FormaCalculo13ro")]
    public int? FormaCalculo13ro { get; set; }

    [JsonProperty("FormaCalculo14ro")]
    public int? FormaCalculo14ro { get; set; }

    [JsonProperty("BoniComplementaria")]
    public int? BonificacionComplementaria { get; set; }

    [JsonProperty("BoniEspecial")]
    public int? BonificacionEspecial { get; set; }

    [JsonProperty("Remuneracion_Minima")]
    public int? RemuneracionMinima { get; set; }

    [JsonProperty("CuotaCuentaCorriente")]
    public int? CuotaCuentaCorriente { get; set; }

    [JsonProperty("Fondo_Reserva")]
    public string? FondoReserva { get; set; } = string.Empty;

    public string? Mensaje { get; set; } = string.Empty;
}
