using RecursosHumanos.Client.Services.Http;
using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests.Trabajador;

namespace RecursosHumanos.Client.Services.TrabajadorService;

public class TrabajadorService : ITrabajadorService
{
    private readonly IRestClientService _client;

    public TrabajadorService(IRestClientService client)
    {
        _client = client;
    }

    public Task Delete(DeleteTrabajadorRequest request)
    {
        return _client.Delete("Trabajador/delete", request);
    }

    public Task<List<Trabajador>> GetAllBySucursal(int sucursal)
    {
        return _client.Get<List<Trabajador>>($"Trabajador?codigoSucursal={sucursal}");
    }

    public Task<Trabajador> GetById(int id, int sucursal)
    {
        return _client.Get<Trabajador>($"Trabajador/getById?codigoSucursal={sucursal}&id={id}");
    }

    public Task Insert(InsertTrabajadorRequest request)
    {
        return _client.Post($"Trabajador/insert", request);
    }

    public Task Update(UpdateTrabajadorRequest request)
    {
        return _client.Put($"Trabajador/update", request);
    }
}
