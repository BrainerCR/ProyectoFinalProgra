using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class FamiliaProducto
    {
        public FamiliaProducto()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdFamiliaProducto { get; set; }
        public string NombreFamiliaProducto { get; set; }
        public int CodigoCabys { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
