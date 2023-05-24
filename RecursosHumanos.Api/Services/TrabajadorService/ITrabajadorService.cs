using ErrorOr;
using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests.Trabajador;

namespace RecursosHumanos.Api.Services.TrabajadorService;

public interface ITrabajadorService
{
    public Task<ErrorOr<List<Trabajador>>> GetAllBySucursal(int CodigoSucursal);
    public Task<ErrorOr<bool>> Insert(InsertTrabajadorRequest request); 
    public Task<ErrorOr<bool>> Update(UpdateTrabajadorRequest request); 
    public Task<ErrorOr<bool>> Delete(DeleteTrabajadorRequest request);
}
