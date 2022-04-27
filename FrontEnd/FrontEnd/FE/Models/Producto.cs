using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FE.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la fecha de ingreso del producto")]
        [DisplayName("Fecha Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el nombre del producto")]
        [DisplayName("Nombre")]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la cantidad del producto")]
        [DisplayName("Cantidad")]
        public int CantidadProducto { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el precio unitario del producto")]
        [DisplayName("Precio Unitario")]
        public int PrecioUnitario { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el precio de venta del producto")]
        [DisplayName("Precio Venta")]
        public int PrecioVenta { get; set; }

        [Required(ErrorMessage = "Por favor seleccione el tipo de producto")]
        [DisplayName("Tipo")]
        public int IdVinculoProducto { get; set; }

        [Required(ErrorMessage = "Por favor seleccione el distribuidor del producto")]
        [DisplayName("Distribuidor")]
        public int IdDistribuidor { get; set; }

        [DisplayName("Distribuidor")]
        public virtual Distribuidor IdDistribuidorNavigation { get; set; }

        [DisplayName("Tipo")]
        public virtual VinculoProducto IdVinculoProductoNavigation { get; set; }
    }
}
