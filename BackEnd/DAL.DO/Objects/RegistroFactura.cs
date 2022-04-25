using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public partial class RegistroFactura
    {
        public int IdRegistro { get; set; }
        public string CodigoRegistro { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaFactura { get; set; }
        public int TotalFactura { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
    }
}
