using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadProducto { get; set; }
        public int PrecioUnitario { get; set; }
        public int PrecioVenta { get; set; }
        public int IdVinculoProducto { get; set; }
        public int IdDistribuidor { get; set; }

        //Descomentar cuando se tenga creado sus clases respectivas
        //public virtual Distribuidor IdDistribuidorNavigation { get; set; }
        //public virtual VinculoProducto IdVinculoProductoNavigation { get; set; }
    }
}
