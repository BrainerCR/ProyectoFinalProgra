using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public partial class Cliente
    {
        public Cliente()
        {
            RegistroFactura = new HashSet<RegistroFactura>();
        }

        public int IdCliente { get; set; }
        public int CedulaCliente { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NombreCliente { get; set; }
        public string CorreoEmpleado { get; set; }
        public string Provincia { get; set; }

        public virtual ICollection<RegistroFactura> RegistroFactura { get; set; }
    }
}
