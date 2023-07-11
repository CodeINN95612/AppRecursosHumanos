using ErrorOr;
using Newtonsoft.Json;
using RecursosHumanos.Api.DTO.Ecuasol;
using RecursosHumanos.Api.DTO.Errors;
using RecursosHumanos.Shared.Data;
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
        string msg = JsonConvert.DeserializeObject<string>(contentString) ?? "";

        if (msg.ToLower().Trim() != "Eliminación Exitosa".ToLower())
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
            c.CodigoSucursal ?? 0,
            c.Id ?? 0,
            c.ApellidoPaterno?.Trim() ?? "",
            c.ApellidoMaterno?.Trim() ?? "",
            c.Nombres?.Trim() ?? "",
            c.Identificacion?.Trim() ?? "",
            c.EntidadBancaria?.Trim() ?? "",
            c.CarnetIESS?.Trim() ?? "",
            c.Direccion?.Trim() ?? "",
            c.TelefonoFijo?.Trim() ?? "",
            c.TelefonoMovil?.Trim() ?? "",
            c.NumeroCuentaBancaria?.Trim() ?? "",
            CategoriaOcupacion.FromCodigo(c.CargoCategoriaOcupacion ?? ""),
            Ocupacion.FromCodigo(c.Ocupacion ?? ""),
            NivelSalarial.FromCodigo(c.NivelSalarial ?? ""),
            c.TipoComision?.Trim() ?? "",
            c.FechaNacimiento ?? DateTime.MinValue,
            c.FechaIngreso ?? DateTime.MinValue,
            c.FechaCese ?? DateTime.MinValue,
            c.PeriodoVacaciones ?? 0,
            c.FechaReingreso ?? DateTime.MinValue,
            c.FechaUltimaActualizacion ?? DateTime.MinValue,
            c.BancoCTA_CTE,
            c.BonificacionComplementaria ?? 0,
            c.BonificacionEspecial ?? 0,
            c.RemuneracionMinima ?? 0,
            c.CuotaCuentaCorriente ?? 0,
            FondoReserva.FromCodigo(c.FondoReserva ?? ""),
            c.Mensaje?.Trim() ?? "",
            c.CentroCostos?.Trim() ?? "",
            c.EstadoTrabajador?.Trim() ?? "",
            c.TipoTrabajador?.Trim() ?? "",
            c.TipoContrato?.Trim() ?? "", 
            c.TipoCese?.Trim() ?? "", 
            c.EstadoCivil?.Trim() ?? "", 
            c.TipoCuenta?.Trim() ?? "",
            c.EsReingreso?.Trim() ?? "",
            c.Sexo?.Trim() ?? "")).ToList();
    }

    public async Task<ErrorOr<bool>> Insert(InsertTrabajadorRequest request)
    {
        if(!_ValidaCedulaORuc(request.Identificacion))
        {
            return GeneralErrors.InvalidId;
        }

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
            $"&FechaNacimiento={request.FechaNacimiento:MM/dd/yyyy}" +
            $"&FechaIngreso={request.FechaIngreso:MM/dd/yyyy}" +
            $"&FechaCese={request.FechaCese:MM/dd/yyyy}" +
            $"&PeriododeVacaciones={request.PeriodoVacaciones}" +
            $"&FechaReingreso={request.FechaReingreso:MM/dd/yyyy}" +
            $"&Fecha_Ult_Actualizacion={DateTime.Now:MM/dd/yyyy}" +
            $"&EsReingreso={request.CodigoEsReingreso}" +
            //$"&BancoCTA_CTE={request.BancoCTA_CTE}" +
            $"&Tipo_Cuenta={request.CodigoTipoCuenta}" +
            //$"&RSV_Indem_Acumul={0}" +
            //$"&A%C3%B1o_Ult_Rsva_Indemni={0}" +
            //$"&Mes_Ult_Rsva_Indemni={0}" +
            $"&FormaCalculo13ro={1}" +
            $"&FormaCalculo14ro={1}" +
            $"&BoniComplementaria={request.BonificacionComplementaria}" +
            $"&BoniEspecial={request.BonificacionEspecial}" +
            $"&Remuneracion_Minima={request.RemuneracionMinima}" +
            //$"&CuotaCuentaCorriente={request.CuotaCuentaCorriente}" +
            $"&Fondo_Reserva={request.FondoReserva}" +
            $"&Mensaje={request.Mensaje}";

        var response = await _httpClient.PostAsJsonAsync($"Varios/TrabajadorInsert?{insert}", new { });

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string contentString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        string msg = JsonConvert.DeserializeObject<string>(contentString) ?? "";

        if (msg.ToLower().Trim() != "Ingreso Exitoso".ToLower())
        {
            return GeneralErrors.NotFound;
        }

        return true;
    }
    public async Task<ErrorOr<bool>> Update(UpdateTrabajadorRequest request)
    {
        if (!_ValidaCedulaORuc(request.Identificacion))
        {
            return GeneralErrors.InvalidId;
        }

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
            $"&FechaNacimiento={request.FechaNacimiento:MM/dd/yyyy}" +
            $"&FechaIngreso={request.FechaIngreso:MM/dd/yyyy}" +
            $"&FechaCese={request.FechaCese:MM/dd/yyyy}" +
            $"&PeriododeVacaciones={request.PeriodoVacaciones}" +
            $"&FechaReingreso={request.FechaReingreso:MM/dd/yyyy}" +
            $"&Fecha_Ult_Actualizacion={DateTime.Now:MM/dd/yyyy}" +
            $"&EsReingreso={request.CodigoEsReingreso}" +
            //$"&BancoCTA_CTE={request.BancoCTA_CTE}" +
            $"&Tipo_Cuenta={request.CodigoTipoCuenta}" +
            //$"&RSV_Indem_Acumul={0}" +
            //$"&A%C3%B1o_Ult_Rsva_Indemni={0}" +
            //$"&Mes_Ult_Rsva_Indemni={0}" +
            $"&FormaCalculo13ro={1}" +
            $"&FormaCalculo14ro={1}" +
            $"&BoniComplementaria={request.BonificacionComplementaria}" +
            $"&BoniEspecial={request.BonificacionEspecial}" +
            $"&Remuneracion_Minima={request.RemuneracionMinima}" +
            //$"&CuotaCuentaCorriente={request.CuotaCuentaCorriente}" +
            $"&Fondo_Reserva={request.FondoReserva}" +
            $"&Mensaje={request.Mensaje}";

        var response = await _httpClient.PostAsJsonAsync($"Varios/TrabajadorUpdate?{update}", new { });

        if (response is null || !response.IsSuccessStatusCode)
        {
            return GeneralErrors.NotFound;
        }

        var jsonContent = await response.Content.ReadAsStringAsync();
        string contentString = JsonConvert.DeserializeObject<string>(jsonContent) ?? "";
        string msg = JsonConvert.DeserializeObject<string>(contentString) ?? "";

        if (msg.ToLower().Trim() != "Actualización  Exitosa".ToLower())
        {
            return GeneralErrors.NotFound;
        }

        return true;
    }

    private static bool _ValidaCedulaORuc(string identificacion)
    {
        bool estado = false;
        char[] valced = new char[13];
        int provincia;
        if (identificacion.Length >= 10)
        {
            valced = identificacion.Trim().ToCharArray();
            provincia = int.Parse((valced[0].ToString() + valced[1].ToString()));
            if (provincia > 0 && provincia < 25)
            {
                if (int.Parse(valced[2].ToString()) < 6)
                {
                    estado = _VerificaCedula(valced);
                }
                else if (int.Parse(valced[2].ToString()) == 6)
                {
                    estado = _VerificaSectorPublico(valced);
                }
                else if (int.Parse(valced[2].ToString()) == 9)
                {

                    estado = _VerificaPersonaJuridica(valced);
                }
            }
        }
        return estado;
    }

    private static bool _VerificaCedula(char[] validarCedula)
    {
        int aux = 0, par = 0, impar = 0, verifi;
        for (int i = 0; i < 9; i += 2)
        {
            aux = 2 * int.Parse(validarCedula[i].ToString());
            if (aux > 9)
                aux -= 9;
            par += aux;
        }
        for (int i = 1; i < 9; i += 2)
        {
            impar += int.Parse(validarCedula[i].ToString());
        }

        aux = par + impar;
        if (aux % 10 != 0)
        {
            verifi = 10 - (aux % 10);
        }
        else
            verifi = 0;
        if (verifi == int.Parse(validarCedula[9].ToString()))
            return true;
        else
            return false;
    }

    private static bool _VerificaPersonaJuridica(char[] validarCedula)
    {
        int aux = 0, prod, veri;
        veri = int.Parse(validarCedula[10].ToString()) + int.Parse(validarCedula[11].ToString()) + int.Parse(validarCedula[12].ToString());
        if (veri > 0)
        {
            int[] coeficiente = new int[9] { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < 9; i++)
            {
                prod = int.Parse(validarCedula[i].ToString()) * coeficiente[i];
                aux += prod;
            }
            if (aux % 11 == 0)
            {
                veri = 0;
            }
            else if (aux % 11 == 1)
            {
                return false;
            }
            else
            {
                aux = aux % 11;
                veri = 11 - aux;
            }

            if (veri == int.Parse(validarCedula[9].ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private static bool _VerificaSectorPublico(char[] validarCedula)
    {
        int aux = 0, prod, veri;
        veri = int.Parse(validarCedula[9].ToString()) + int.Parse(validarCedula[10].ToString()) + int.Parse(validarCedula[11].ToString()) + int.Parse(validarCedula[12].ToString());
        if (veri > 0)
        {
            int[] coeficiente = new int[8] { 3, 2, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < 8; i++)
            {
                prod = int.Parse(validarCedula[i].ToString()) * coeficiente[i];
                aux += prod;
            }

            if (aux % 11 == 0)
            {
                veri = 0;
            }
            else if (aux % 11 == 1)
            {
                return false;
            }
            else
            {
                aux = aux % 11;
                veri = 11 - aux;
            }

            if (veri == int.Parse(validarCedula[8].ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
