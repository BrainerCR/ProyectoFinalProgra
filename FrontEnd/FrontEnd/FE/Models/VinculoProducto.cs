using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FE.Models
{
    public partial class VinculoProducto
    {
        public VinculoProducto()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdVinculoProducto { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el tipo de producto")]
        [DisplayName("Tipo")]
        public string NombreVinculoProducto { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
