using AppControlVehiculos.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppControlVehiculos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepositorio _repositorio;

        public MarcaController(IMarcaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var data = await _repositorio.Listar();
            return Ok(data);
        }
    }
}
