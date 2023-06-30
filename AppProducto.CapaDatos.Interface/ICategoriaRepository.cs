using AppProducto.CapaNegocio.Entity;

namespace AppProducto.CapaDatos.Interface
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetListaCategorias();
        Task<Categoria> GetCategoriaById(int id);
        Task<bool> InsertarCategoria(Categoria categoria);
        Task<bool> ActualizarCategoria(Categoria categoria);
        Task<bool> EliminarCategoria(int id);
    }
}
