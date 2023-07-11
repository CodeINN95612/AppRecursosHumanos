using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Client.Data.Forms;

public class TrabajadorForm
{
    [Required]
    public int CodigoSucursal { get; set; }
    [Required]
    public int IdTrabajador { get; set; }
    [Required(AllowEmptyStrings = false)]
    public string CodigoTipoTrabajador { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    [MaxLength(20)]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El apellido paterno debe contener solo letras")]
    public string ApellidoPaterno { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    [MaxLength(20)]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El apellido materno debe contener solo letras")]
    public string ApellidoMaterno { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    [MaxLength(35)]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El nombre debe contener solo letras")]
    public string Nombres { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string Identificacion { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string EntidadBancaria { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string CarnetIESS { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string Direccion { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string TelefonoFijo { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string TelefonoMovil { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string CodigoSexo { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string NumeroCuentaBancaria { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string CodigoCategoriaOcupacion { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string Ocupacion { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string CodigoCentroCostos { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string NivelSalarial { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string CodigoEstadoTrabajador { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string CodigoTipoContrato { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string CodigoTipoCese { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string CodigoEstadoCivil { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string TipoComision { get; set; } = string.Empty;
    [Required]
    public DateTime? FechaNacimiento { get; set; } = DateTime.Today;
    [Required]
    public DateTime? FechaIngreso { get; set; } = DateTime.Today;
    [Required]
    public DateTime? FechaCese { get; set; } = DateTime.Today;
    [Required]
    public int PeriodoVacaciones { get; set; }
    [Required]
    public DateTime? FechaReingreso { get; set; } = DateTime.Today;
    [Required(AllowEmptyStrings = false)]
    public string CodigoEsReingreso { get; set; } = string.Empty;
    [Required]
    public int BancoCTA_CTE { get; set; } = 1;
    [Required(AllowEmptyStrings = false)]
    public string CodigoTipoCuenta { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public int BonificacionComplementaria { get; set; }
    [Required(AllowEmptyStrings = false)]
    public int BonificacionEspecial { get; set; }
    [Required(AllowEmptyStrings = false)]
    public int RemuneracionMinima { get; set; }
    [Required(AllowEmptyStrings = false)]
    public int CuotaCuentaCorriente { get; set; }
    [Required(AllowEmptyStrings = false)]
    public string FondoReserva { get; set; } = "1";
    [Required(AllowEmptyStrings = false)]
    public string? Mensaje { get; set; }
}
