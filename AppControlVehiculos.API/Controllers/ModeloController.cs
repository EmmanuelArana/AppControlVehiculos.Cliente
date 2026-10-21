using AppControlVehiculos.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppControlVehiculos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ModeloController : ControllerBase
    {
        private readonly IModeloRepositorio _repositorio;

        public ModeloController(IModeloRepositorio repositorio)
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
