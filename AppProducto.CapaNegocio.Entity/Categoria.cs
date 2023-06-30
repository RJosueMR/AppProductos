using System.ComponentModel.DataAnnotations;

namespace AppProducto.CapaNegocio.Entity
{
    public class Categoria
    {
        [Display(Name = "ID")]
        public int ID_Categoria { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}