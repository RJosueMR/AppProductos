using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProducto.CapaNegocio.Entity
{
    public class Producto
    {
        [Display(Name = "ID")]
        public int ID_Producto { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Precio")]
        public double Precio { get; set; }
        [Display(Name = "Categoría")]
        public int ID_Categoria { get; set; }
    }
}
