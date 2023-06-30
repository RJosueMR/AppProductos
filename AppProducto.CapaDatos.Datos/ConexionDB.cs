using AppProducto.CapaTransversal.Comun;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AppProducto.CapaDatos.Datos
{
    public class ConexionDB : IConexionDB
    {
        private readonly IConfiguration _configuration;

        public ConexionDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetDbConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection != null)
                {
                    sqlConnection.ConnectionString = _configuration.GetConnectionString("ConexionDbProductos");
                    sqlConnection.Open();
                }
                return sqlConnection;
            }
        }
    }
}