using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FE.Models
{
    public partial class RegistroFactura
    {
        public int IdRegistro { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el código del registro")]
        [DisplayName("Código")]
        public string CodigoRegistro { get; set; }

        [Required(ErrorMessage = "Por favor selecciones el cliente")]
        [DisplayName("Cliente")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Por favor seleccione el empleado")]
        [DisplayName("Empleado")]
        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la fecha del registro")]
        [DisplayName("Fecha")]
        public DateTime FechaFactura { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el total de la factura")]
        [DisplayName("Total")]
        public int TotalFactura { get; set; }

        [DisplayName("Cliente")]
        public virtual Cliente IdClienteNavigation { get; set; }

        [DisplayName("Empleado")]
        public virtual Empleado IdEmpleadoNavigation { get; set; }
    }
}
