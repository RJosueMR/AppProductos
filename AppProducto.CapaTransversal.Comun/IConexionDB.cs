using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProducto.CapaTransversal.Comun
{
    public interface IConexionDB
    {
        IDbConnection GetDbConnection { get; }
    }
}
