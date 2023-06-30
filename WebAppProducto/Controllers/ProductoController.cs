using AppProducto.CapaDatos.Interface;
using AppProducto.CapaNegocio.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebAppProducto.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ICategoriaRepository _categoriasRepository;
        private readonly IProductoRepository _productoRepository;

        public ProductoController(ICategoriaRepository categoriasRepository, IProductoRepository productoRepository)
        {
            _categoriasRepository = categoriasRepository;
            _productoRepository = productoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var listado = await _productoRepository.GetListaProductos();
            ViewBag.Categorias = await _categoriasRepository.GetListaCategorias();
            return View(listado);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categorias = await _categoriasRepository.GetListaCategorias();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            var resultado = await _productoRepository.InsertarProducto(producto);
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
            ViewBag.Categorias = await _categoriasRepository.GetListaCategorias();
            var producto = await _productoRepository.GetProductoById(id);
            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Producto producto)
        {
            var resultado = await _productoRepository.ActualizarProducto(producto);
            if (resultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var producto = await _productoRepository.GetProductoById(id);
            ViewBag.IDProducto = id;
            return View(producto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _productoRepository.EliminarProducto(id);
            return RedirectToAction("Index");
        }
    }
}
