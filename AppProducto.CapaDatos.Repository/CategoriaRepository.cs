using AppProducto.CapaDatos.Datos;
using AppProducto.CapaDatos.Interface;
using AppProducto.CapaNegocio.Entity;
using AppProducto.CapaTransversal.Comun;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AppProducto.CapaDatos.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly IConexionDB _conexionDB;

        public CategoriaRepository(IConexionDB conexionDB)
        {
            _conexionDB = conexionDB;
        }

        public async Task<IEnumerable<Categoria>> GetListaCategorias()
        {
            using (var conexion = _conexionDB.GetDbConnection)
            {
                string query = "sp_GetListaCategorias";
                var listado = await conexion.QueryAsync<Categoria>(query, commandType: CommandType.StoredProcedure);
                return listado;
            }
        }
        public async Task<Categoria> GetCategoriaById(int id)
        {
            using (var conexion = _conexionDB.GetDbConnection)
            {
                string query = "sp_GetCategoriaById";
                var parametro = new DynamicParameters();
                parametro.Add("ID_Categoria", id);
                var categoria = await conexion.QuerySingleAsync<Categoria>(query, param: parametro, commandType: CommandType.StoredProcedure);
                return categoria;
            }                        
        }
        public async Task<bool> InsertarCategoria(Categoria categoria)
        {
            using (var conexion = _conexionDB.GetDbConnection)
            {
                string query = "sp_InsertarCategoria";
                var parametro = new DynamicParameters();
                parametro.Add("Descripcion", categoria.Descripcion);
                int resultado = await conexion.ExecuteAsync(query, param: parametro, commandType: CommandType.StoredProcedure);
                return resultado > 0;
            }
        }
        public async Task<bool> ActualizarCategoria(Categoria categoria)
        {
            using (var conexion = _conexionDB.GetDbConnection)
            {
                string query = "sp_ActualizarCategoria";
                var parametro = new DynamicParameters();
                parametro.Add("ID_Categoria", categoria.ID_Categoria);
                parametro.Add("Descripcion", categoria.Descripcion);
                int resultado = await conexion.ExecuteAsync(query, param: parametro, commandType: CommandType.StoredProcedure);
                return resultado > 0;
            }
        }
        public async Task<bool> EliminarCategoria(int id)
        {
            using (var conexion = _conexionDB.GetDbConnection)
            {
                string query = "sp_EliminarCategoria";
                var parametro = new DynamicParameters();
                parametro.Add("ID_Categoria", id);
                int resultado = await conexion.ExecuteAsync(query, param: parametro, commandType: CommandType.StoredProcedure);
                return resultado > 0;
            }
        }
    }
}