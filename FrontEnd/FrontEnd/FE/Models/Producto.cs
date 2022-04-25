using System;
using System.Collections.Generic;

namespace FE.Models
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

        public virtual Distribuidor IdDistribuidorNavigation { get; set; }
        public virtual VinculoProducto IdVinculoProductoNavigation { get; set; }
    }
}
