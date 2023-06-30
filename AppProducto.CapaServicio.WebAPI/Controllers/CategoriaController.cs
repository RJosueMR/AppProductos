using AppProducto.CapaDatos.Interface;
using AppProducto.CapaNegocio.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AppProducto.CapaServicio.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriasRepository;

        public CategoriaController(ICategoriaRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertarCategoria([FromBody] Categoria categoria)
        {
            if (categoria != null)
            {
                var respuesta = await _categoriasRepository.InsertarCategoria(categoria);
                if (respuesta)
                {
                    return Ok();
                }
                return BadRequest("Error al insertar");
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarCategoria([FromBody] Categoria categoria)
        {
            if (categoria != null)
            {
                var respuesta = await _categoriasRepository.ActualizarCategoria(categoria);
                if (respuesta)
                {
                    return Ok();
                }
                return BadRequest("Error al Actualizar");
            }
            return BadRequest();
        }
        [HttpDelete("{ID_Categoria}")]
        public async Task<IActionResult> EliminarCategoria(int ID_Categoria)
        {
            if (ID_Categoria > 0)
            {
                var respuesta = await _categoriasRepository.EliminarCategoria(ID_Categoria);
                if (respuesta)
                {
                    return Ok();
                }
                return BadRequest("Error al eliminar");
            }
            return BadRequest();
        }
        [HttpGet("{ID_Categoria}")]
        public async Task<IActionResult> GetCategoriaById(int ID_Categoria)
        {
            if (ID_Categoria > 0)
            {
                var respuesta = await _categoriasRepository.GetCategoriaById(ID_Categoria);
                if (respuesta != null)
                {
                    return Ok(respuesta);
                }
                return BadRequest("La id no fue encontrada");
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetListaCategorias()
        {
            var respuesta = await _categoriasRepository.GetListaCategorias();
            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            return BadRequest();
        }
    }
}
