using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public int CodigoBarras { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NombreProducto { get; set; }
        //public byte[] ImagenProducto { get; set; }
        public int CantidadProducto { get; set; }
        public int PrecioUnitario { get; set; }
        public int PrecioVenta { get; set; }
        public int IdFamiliaProducto { get; set; }
        public int IdProveedor { get; set; }

        public virtual FamiliaProducto IdFamiliaProductoNavigation { get; set; }
        public virtual Proveedor IdProveedorNavigation { get; set; }
    }
}
