using ErrorOr;
using Newtonsoft.Json;
using RecursosHumanos.Api.DTO.Ecuasol;
using RecursosHumanos.Api.DTO.Errors;
using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests.Trabajador;

namespace RecursosHumanos.Api.Services.TrabajadorService;

public class TrabajadorService : ITrabajadorService
{
    private readonly HttpClient _httpClient;

    public TrabajadorService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(Constants.HttpConstants.HttpClientName);
    }

    public async Task<ErrorOr<bool>> Delete(DeleteTrabajadorRequest request)
    {
        var delete = $"sucursal={request.CodigoSucursal}"
            + $"&codigoempleado={request.IdTrabajador}";

        var response = await _httpClient.GetAsync($"Varios/TrabajadorDelete?{delete}");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string contentString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var objs = JsonConvert.DeserializeObject<List<EcuasolTrabajador>>(contentString) ?? new();

        if(objs.Any(o => o.Mensaje is not null))
        {
            return GeneralErrors.NotFound;
        }

        return true;
    }

    public async Task<ErrorOr<List<Trabajador>>> GetAllBySucursal(int CodigoSucursal)
    {
        var response = await _httpClient.GetAsync($"Varios/TrabajadorSelect?sucursal={CodigoSucursal}");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string contentString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var objs = JsonConvert.DeserializeObject<List<EcuasolTrabajador>>(contentString) ?? new();

        return objs.Select(c => new Trabajador(
            c.CodigoSucursal,
            c.Id,
            c.ApellidoPaterno.Trim(),
            c.ApellidoMaterno.Trim(),
            c.Nombres.Trim(),
            c.Identificacion.Trim(),
            c.EntidadBancaria.Trim(),
            c.CarnetIESS.Trim(),
            c.Direccion.Trim(),
            c.TelefonoFijo.Trim(),
            c.TelefonoMovil.Trim(),
            c.NumeroCuentaBancaria.Trim(),
            c.CargoCategoriaOcupacion.Trim(),
            c.Ocupacion.Trim(),
            c.NivelSalarial.Trim(),
            c.TipoComision.Trim(),
            c.FechaNacimiento,
            c.FechaIngreso,
            c.FechaCese,
            c.PeriodoVacaciones,
            c.FechaReingreso,
            c.FechaUltimaActualizacion,
            c.BancoCTA_CTE,
            c.BonificacionComplementaria,
            c.BonificacionEspecial,
            c.RemuneracionMinima,
            c.CuotaCuentaCorriente,
            c.FondoReserva.Trim(),
            c.Mensaje)).ToList();
    }

    public async Task<ErrorOr<bool>> Insert(InsertTrabajadorRequest request)
    {
        var insert = $"COMP_Codigo={request.CodigoSucursal}" +
            $"&Tipo_trabajador={request.CodigoTipoTrabajador}" +
            $"&Apellido_Paterno={request.ApellidoPaterno}" +
            $"&Apellido_Materno={request.ApellidoMaterno}" +
            $"&Nombres={request.Nombres}" +
            $"&Identificacion={request.Identificacion}" +
            $"&Entidad_Bancaria={request.EntidadBancaria}" +
            $"&CarnetIESS={request.CarnetIESS}" +
            $"&Direccion={request.Direccion}" +
            $"&Telefono_Fijo={request.TelefonoFijo}" +
            $"&Telefono_Movil={request.TelefonoMovil}" +
            $"&Genero={request.CodigoSexo}" +
            $"&Nro_Cuenta_Bancaria={request.NumeroCuentaBancaria}" +
            $"&Codigo_Categoria_Ocupacion={request.CodigoCategoriaOcupacion}" +
            $"&Ocupacion={request.Ocupacion}" +
            $"&Centro_Costos={request.CodigoCentroCostos}" +
            $"&Nivel_Salarial={request.NivelSalarial}" +
            $"&EstadoTrabajador={request.CodigoEstadoTrabajador}" +
            $"&Tipo_Contrato={request.CodigoTipoContrato}" +
            $"&Tipo_Cese={request.CodigoTipoCese}" +
            $"&EstadoCivil={request.CodigoEstadoCivil}" +
            $"&TipodeComision={request.TipoComision}" +
            $"&FechaNacimiento={request.FechaNacimiento}" +
            $"&FechaIngreso={request.FechaIngreso}" +
            $"&FechaCese={request.FechaCese}" +
            $"&PeriododeVacaciones={request.PeriodoVacaciones}" +
            $"&FechaReingreso={request.FechaReingreso}" +
            $"&Fecha_Ult_Actualizacion={DateTime.Now}" +
            $"&EsReingreso={request.CodigoEsReingreso}" +
            $"&BancoCTA_CTE={request.BancoCTA_CTE}" +
            $"&Tipo_Cuenta={request.CodigoTipoCuenta}" +
            $"&RSV_Indem_Acumul={0}" +
            $"&A%C3%B1o_Ult_Rsva_Indemni={0}" +
            $"&Mes_Ult_Rsva_Indemni={0}" +
            $"&FormaCalculo13ro={1}" +
            $"&FormaCalculo14ro={1}" +
            $"&BoniComplementaria={request.BonificacionComplementaria}" +
            $"&BoniEspecial={request.BonificacionEspecial}" +
            $"&Remuneracion_Minima={request.RemuneracionMinima}" +
            $"&CuotaCuentaCorriente={request.CuotaCuentaCorriente}" +
            $"&Fondo_Reserva={request.FondoReserva}" +
            $"&Mensaje={request.Mensaje}";

        var response = await _httpClient.GetAsync($"Varios/TrabajadorInsert?{insert}");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string contentString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var objs = JsonConvert.DeserializeObject<List<EcuasolTrabajador>>(contentString) ?? new();

        if (objs.Any(o => o.Mensaje is not null))
        {
            return GeneralErrors.NotFound;
        }

        return true;
    }

    public async Task<ErrorOr<bool>> Update(UpdateTrabajadorRequest request)
    {
        var update = $"COMP_Codigo={request.CodigoSucursal}" +
            $"&Id_Trabajador={request.IdTrabajador}" +
            $"&Tipo_trabajador={request.CodigoTipoTrabajador}" +
            $"&Apellido_Paterno={request.ApellidoPaterno}" +
            $"&Apellido_Materno={request.ApellidoMaterno}" +
            $"&Nombres={request.Nombres}" +
            $"&Identificacion={request.Identificacion}" +
            $"&Entidad_Bancaria={request.EntidadBancaria}" +
            $"&CarnetIESS={request.CarnetIESS}" +
            $"&Direccion={request.Direccion}" +
            $"&Telefono_Fijo={request.TelefonoFijo}" +
            $"&Telefono_Movil={request.TelefonoMovil}" +
            $"&Genero={request.CodigoSexo}" +
            $"&Nro_Cuenta_Bancaria={request.NumeroCuentaBancaria}" +
            $"&Codigo_Categoria_Ocupacion={request.CodigoCategoriaOcupacion}" +
            $"&Ocupacion={request.Ocupacion}" +
            $"&Centro_Costos={request.CodigoCentroCostos}" +
            $"&Nivel_Salarial={request.NivelSalarial}" +
            $"&EstadoTrabajador={request.CodigoEstadoTrabajador}" +
            $"&Tipo_Contrato={request.CodigoTipoContrato}" +
            $"&Tipo_Cese={request.CodigoTipoCese}" +
            $"&EstadoCivil={request.CodigoEstadoCivil}" +
            $"&TipodeComision={request.TipoComision}" +
            $"&FechaNacimiento={request.FechaNacimiento}" +
            $"&FechaIngreso={request.FechaIngreso}" +
            $"&FechaCese={request.FechaCese}" +
            $"&PeriododeVacaciones={request.PeriodoVacaciones}" +
            $"&FechaReingreso={request.FechaReingreso}" +
            $"&Fecha_Ult_Actualizacion={DateTime.Now}" +
            $"&EsReingreso={request.CodigoEsReingreso}" +
            $"&BancoCTA_CTE={request.BancoCTA_CTE}" +
            $"&Tipo_Cuenta={request.CodigoTipoCuenta}" +
            $"&RSV_Indem_Acumul={0}" +
            $"&A%C3%B1o_Ult_Rsva_Indemni={0}" +
            $"&Mes_Ult_Rsva_Indemni={0}" +
            $"&FormaCalculo13ro={1}" +
            $"&FormaCalculo14ro={1}" +
            $"&BoniComplementaria={request.BonificacionComplementaria}" +
            $"&BoniEspecial={request.BonificacionEspecial}" +
            $"&Remuneracion_Minima={request.RemuneracionMinima}" +
            $"&CuotaCuentaCorriente={request.CuotaCuentaCorriente}" +
            $"&Fondo_Reserva={request.FondoReserva}" +
            $"&Mensaje={request.Mensaje}";

        var response = await _httpClient.GetAsync($"Varios/TrabajadorUpdate?{update}");

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string contentString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        var objs = JsonConvert.DeserializeObject<List<EcuasolTrabajador>>(contentString) ?? new();

        if (objs.Any(o => o.Mensaje is not null))
        {
            return GeneralErrors.NotFound;
        }

        return true;
    }
}
