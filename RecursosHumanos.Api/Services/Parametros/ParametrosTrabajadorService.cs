using ErrorOr;
using Newtonsoft.Json;
using RecursosHumanos.Api.DTO.Ecuasol;
using RecursosHumanos.Api.DTO.Errors;
using RecursosHumanos.Api.Services.TrabajadorService;
using RecursosHumanos.Shared.Models;
using System;

namespace RecursosHumanos.Api.Services.Parametros;

public class ParametrosTrabajadorService : IParametrosTrabajadorService
{
    private HttpClient _httpClient;

    private ITrabajadorService _trabajadorService;

    public ParametrosTrabajadorService(IHttpClientFactory httpFactory, ITrabajadorService trabajadorService)
    {
        _httpClient = httpFactory.CreateClient(Constants.HttpConstants.HttpClientName);
        _trabajadorService = trabajadorService;
    }

    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllEsReingreso()
    {
        return _ObtenerParametro("Varios/EsReingreso");
    }

    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllEstadoCivil()
    {
        return _ObtenerParametro("Varios/EstadoCivil");
    }

    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllEstadoTrabajador()
    {
        return _ObtenerParametro("Varios/EstadoTrabajador");
    }

    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllSexo()
    {
        return _ObtenerParametro("Varios/Genero");
    }

    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllTipoCese()
    {
        return _ObtenerParametro("Varios/TipoCese");
    }

    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllTipoContrato()
    {
        return _ObtenerParametro("Varios/TipoContrato");
    }

    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllTipoCuenta()
    {
        return _ObtenerParametro("Varios/TipoCuenta");
    }

    public Task<ErrorOr<List<ParametroTrabajador>>> GetAllTipoTrabajador()
    {
        return _ObtenerParametro("Varios/TipoTrabajador");
    }

    public async Task<ErrorOr<List<string>>> GetAllCategoriaOcupacion()
    {
        HashSet<string> ocupaciones = new HashSet<string>();
        for (int i = 1; i <= 18; i++)
        {
            var trabajadoresResult = await _trabajadorService.GetAllBySucursal(i);
            if (trabajadoresResult.IsError)
            {
                return trabajadoresResult.Errors.ToList();
            }

            var trabajadores = trabajadoresResult.Value;
            foreach (var trabajador in trabajadores)
            {
                ocupaciones.Add(trabajador.FondoReserva.Trim().ToUpper());
            }
            await Task.Delay(1000);
        }
        return ocupaciones.ToList();
    }

    private async Task<ErrorOr<List<ParametroTrabajador>>> _ObtenerParametro(string uri)
    {
        var response = await _httpClient.GetAsync(uri);

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string objString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var obj = JsonConvert.DeserializeObject<List<EcuasolParametro>>(objString) ?? new();

        return obj.Select(e => new ParametroTrabajador(e.Codigo, e.Nombre)).ToList();
    }
}
