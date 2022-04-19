using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class HistorialFactura
    {
        public int IdFactura { get; set; }
        public string CodigoFactura { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaFactura { get; set; }
        public int TotalFactura { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
    }
}
