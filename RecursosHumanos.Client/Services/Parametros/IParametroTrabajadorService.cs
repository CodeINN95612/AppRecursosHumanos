using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Client.Services.Parametros;

public interface IParametroTrabajadorService
{
    public Task<List<ParametroTrabajador>> GetAllSexo();
    public Task<List<ParametroTrabajador>> GetAllTipoTrabajador();
    public Task<List<ParametroTrabajador>> GetAllEstadoTrabajador();
    public Task<List<ParametroTrabajador>> GetAllTipoContrato();
    public Task<List<ParametroTrabajador>> GetAllTipoCese();
    public Task<List<ParametroTrabajador>> GetAllEstadoCivil();
    public Task<List<ParametroTrabajador>> GetAllEsReingreso();
    public Task<List<ParametroTrabajador>> GetAllTipoCuenta();
}
