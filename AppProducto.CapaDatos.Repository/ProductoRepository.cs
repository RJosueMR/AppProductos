using AppProducto.CapaDatos.Interface;
using AppProducto.CapaNegocio.Entity;
using AppProducto.CapaTransversal.Comun;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProducto.CapaDatos.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IConexionDB _conexionDB;

        public ProductoRepository(IConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }

        public async Task<IEnumerable<Producto>> GetListaProductos()
        {
            using (var conexion = _conexionDB.GetDbConnection)
            {
                string query = "sp_GetListaProductos";
                var listado = await conexion.QueryAsync<Producto>(query, commandType: CommandType.StoredProcedure);
                return listado;
            }
        }

        public async Task<Producto> GetProductoById(int id)
        {
            using (var conexion = _conexionDB.GetDbConnection)
            {
                string query = "sp_GetProductoById";
                var parametro = new DynamicParameters();
                parametro.Add("ID_Producto", id);
                var categoria = await conexion.QuerySingleAsync<Producto>(query, param: parametro, commandType: CommandType.StoredProcedure);
                return categoria;
            }
        }
        public async Task<bool> InsertarProducto(Producto producto)
        {
            using (var conexion = _conexionDB.GetDbConnection)
            {
                string query = "sp_InsertarProducto";
                var parametro = new DynamicParameters();
                parametro.Add("Descripcion", producto.Descripcion);
                parametro.Add("Precio", producto.Precio);
                parametro.Add("ID_Categoria", producto.ID_Categoria);
                int resultado = await conexion.ExecuteAsync(query, param: parametro, commandType: CommandType.StoredProcedure);
                return resultado > 0;
            }
        }

        public async Task<bool> ActualizarProducto(Producto producto)
        {
            using (var conexion = _conexionDB.GetDbConnection)
            {
                string query = "sp_ActualizarProducto";
                var parametro = new DynamicParameters();
                parametro.Add("ID_Producto", producto.ID_Producto);
                parametro.Add("Descripcion", producto.Descripcion);
                parametro.Add("Precio", producto.Precio);
                parametro.Add("ID_Categoria", producto.ID_Categoria);
                int resultado = await conexion.ExecuteAsync(query, param: parametro, commandType: CommandType.StoredProcedure);
                return resultado > 0;
            }
        }

        public async Task<bool> EliminarProducto(int id)
        {
            using (var conexion = _conexionDB.GetDbConnection)
            {
                string query = "sp_EliminarProducto";
                var parametro = new DynamicParameters();
                parametro.Add("ID_Producto", id);
                int resultado = await conexion.ExecuteAsync(query, param: parametro, commandType: CommandType.StoredProcedure);
                return resultado > 0;
            }
        }
    }
}
