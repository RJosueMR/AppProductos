using AppProducto.CapaNegocio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProducto.CapaDatos.Interface
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetListaProductos();
        Task<Producto> GetProductoById(int id);
        Task<bool> InsertarProducto(Producto producto);
        Task<bool> ActualizarProducto(Producto producto);
        Task<bool> EliminarProducto(int id);
    }
}
