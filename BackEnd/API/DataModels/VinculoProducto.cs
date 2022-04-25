using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataModels
{
    public class VinculoProducto
    {
        //public VinculoProducto()
        //{
        //    Producto = new HashSet<Producto>();
        //}

        public int IdVinculoProducto { get; set; }
        public string NombreVinculoProducto { get; set; }

        //public virtual ICollection<Producto> Producto { get; set; }
    }
}
