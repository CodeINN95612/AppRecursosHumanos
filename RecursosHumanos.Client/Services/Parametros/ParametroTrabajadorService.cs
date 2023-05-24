using RecursosHumanos.Client.Services.Http;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Client.Services.Parametros;

public class ParametroTrabajadorService : IParametroTrabajadorService
{
    private IRestClientService _restClientService;

    public ParametroTrabajadorService(IRestClientService restClientService)
    {
        _restClientService = restClientService;
    }

    public Task<List<ParametroTrabajador>> GetAllEsReingreso()
    {
        return _restClientService.Get<List<ParametroTrabajador>>("ParametrosTrabajador/getAllEsReingreso");
    }

    public Task<List<ParametroTrabajador>> GetAllEstadoCivil()
    {
        return _restClientService.Get<List<ParametroTrabajador>>("ParametrosTrabajador/getAllEstadoCivil");
    }

    public Task<List<ParametroTrabajador>> GetAllEstadoTrabajador()
    {
        return _restClientService.Get<List<ParametroTrabajador>>("ParametrosTrabajador/getAllEstadoTrabajador");
    }

    public Task<List<ParametroTrabajador>> GetAllSexo()
    {
        return _restClientService.Get<List<ParametroTrabajador>>("ParametrosTrabajador/getAllSexo");
    }

    public Task<List<ParametroTrabajador>> GetAllTipoCese()
    {
        return _restClientService.Get<List<ParametroTrabajador>>("ParametrosTrabajador/getAllTipoCese");
    }

    public Task<List<ParametroTrabajador>> GetAllTipoContrato()
    {
        return _restClientService.Get<List<ParametroTrabajador>>("ParametrosTrabajador/getAllTipoContrato");
    }

    public Task<List<ParametroTrabajador>> GetAllTipoCuenta()
    {
        return _restClientService.Get<List<ParametroTrabajador>>("ParametrosTrabajador/getAllTipoCuenta");
    }

    public Task<List<ParametroTrabajador>> GetAllTipoTrabajador()
    {
        return _restClientService.Get<List<ParametroTrabajador>>("ParametrosTrabajador/getAllTipoTrabajador");
    }
}
