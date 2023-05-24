using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests.Trabajador;

namespace RecursosHumanos.Client.Services.TrabajadorService;

public interface ITrabajadorService
{
    public Task<List<Trabajador>> GetAllBySucursal(int sucursal);
    public Task<Trabajador> GetById(int id, int sucursal);
    public Task Insert(InsertTrabajadorRequest request);
    public Task Update(UpdateTrabajadorRequest request);
    public Task Delete(DeleteTrabajadorRequest request);
}
