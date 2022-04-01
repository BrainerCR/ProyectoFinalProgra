using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public partial class VinculoProducto
    {
        public VinculoProducto()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdVinculoProducto { get; set; }
        public string NombreVinculoProducto { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
