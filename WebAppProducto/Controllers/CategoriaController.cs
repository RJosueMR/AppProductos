using AppProducto.CapaDatos.Interface;
using AppProducto.CapaDatos.Repository;
using AppProducto.CapaNegocio.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebAppProducto.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriasRepository;

        public CategoriaController(ICategoriaRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }

        public async Task<IActionResult> Index()
        {
            var listado = await _categoriasRepository.GetListaCategorias();
            return View(listado);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            var resultado = await _categoriasRepository.InsertarCategoria(categoria);
            if (resultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriasRepository.GetCategoriaById(id);
            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Categoria categoria)
        {
            var resultado = await _categoriasRepository.ActualizarCategoria(categoria);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var categoria = await _categoriasRepository.GetCategoriaById(id);
            ViewBag.IDCategoria = id;
            return View(categoria);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoriasRepository.EliminarCategoria(id);
            return RedirectToAction("Index");
        }
    }
}
