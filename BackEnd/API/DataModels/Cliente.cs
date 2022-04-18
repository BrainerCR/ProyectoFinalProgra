using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataModels
{
    public class Cliente
    {
        //public Cliente()
        //{
        //    RegistroFactura = new HashSet<RegistroFactura>();
        //}

        public int IdCliente { get; set; }
        public int CedulaCliente { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NombreCliente { get; set; }
        public string CorreoEmpleado { get; set; }
        public string Provincia { get; set; }

        //public virtual ICollection<RegistroFactura> RegistroFactura { get; set; }
    }
}
