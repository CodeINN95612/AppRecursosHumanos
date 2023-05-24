using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Api.Services.Parametros;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ParametrosTrabajadorController : RecursosHumanosApi
    {
        private readonly IParametrosTrabajadorService _service;

        public ParametrosTrabajadorController(IParametrosTrabajadorService service)
        {
            _service = service;
            
        }

        [HttpGet("getAllSexo")]
        public async Task<IActionResult> GetAllSexo()
        {
            var list = await _service.GetAllSexo();
            return list.Match(Ok, Problem);
        }

        [HttpGet("getAllTipoTrabajador")]
        public async Task<IActionResult> GetAllTipoTrabajador()
        {
            var list = await _service.GetAllTipoTrabajador();
            return list.Match(Ok, Problem);
        }

        [HttpGet("getAllEstadoTrabajador")]
        public async Task<IActionResult> GetAllEstadoTrabajador()
        {
            var list = await _service.GetAllEstadoTrabajador();
            return list.Match(Ok, Problem);
        }

        [HttpGet("getAllTipoContrato")]
        public async Task<IActionResult> GetAllTipoContrato()
        {
            var list = await _service.GetAllTipoContrato();
            return list.Match(Ok, Problem);
        }

        [HttpGet("getAllTipoCese")]
        public async Task<IActionResult> GetAllTipoCese()
        {
            var list = await _service.GetAllTipoCese();
            return list.Match(Ok, Problem);
        }

        [HttpGet("getAllEstadoCivil")]
        public async Task<IActionResult> GetAllEstadoCivil()
        {
            var list = await _service.GetAllEstadoCivil();
            return list.Match(Ok, Problem);
        }

        [HttpGet("getAllEsReingreso")]
        public async Task<IActionResult> GetAllEsReingreso()
        {
            var list = await _service.GetAllEsReingreso();
            return list.Match(Ok, Problem);
        }

        [HttpGet("getAllTipoCuenta")]
        public async Task<IActionResult> GetAllTipoCuenta()
        {
            var list = await _service.GetAllTipoCuenta();
            return list.Match(Ok, Problem);
        }

    }
}
