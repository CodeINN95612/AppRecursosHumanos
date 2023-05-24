using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Api.Services.TrabajadorService;
using RecursosHumanos.Shared.Requests.Trabajador;

namespace RecursosHumanos.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class TrabajadorController : RecursosHumanosApi
    {
        private readonly ITrabajadorService _service;

        public TrabajadorController(ITrabajadorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBySucursal(int codigoSucursal)
        {
            var list = await _service.GetAllBySucursal(codigoSucursal);
            return list.Match(Ok, Problem);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int codigoSucursal, int id)
        {
            var list = await _service.GetAllBySucursal(codigoSucursal);
            return list.Match(
                e => Ok(e.FirstOrDefault(d => d.IdTrabajador == id)),
                Problem);
        }
        [HttpPost("insert")]
        public async Task<IActionResult> Insert(InsertTrabajadorRequest request)
        {
            var movimientoResult = await _service.Insert(request);
            return movimientoResult.Match(_ => Ok(), Problem);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateTrabajadorRequest request)
        {
            var movimientoResult = await _service.Update(request);
            return movimientoResult.Match(_ => Ok(), Problem);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteTrabajadorRequest request)
        {
            var movimientoResult = await _service.Delete(request);
            return movimientoResult.Match(_ => Ok(), Problem);
        }
    }
}
