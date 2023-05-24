using ErrorOr;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.Parametros;

public interface IParametrosTrabajadorService
{
    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllSexo();
    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllTipoTrabajador();
    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllEstadoTrabajador();
    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllTipoContrato();
    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllTipoCese();
    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllEstadoCivil();
    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllEsReingreso();
    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllTipoCuenta();
}
