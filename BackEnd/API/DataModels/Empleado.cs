using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataModels
{
    public class Empleado
    {
        //public Empleado()
        //{
        //    RegistroFactura = new HashSet<RegistroFactura>();
        //}

        public int IdEmpleado { get; set; }
        public int CedulaEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string CorreoEmpleado { get; set; }
        public string ClaveEmpleado { get; set; }
        public string Provincia { get; set; }
        public string TelefonoEmpleado { get; set; }
        public int IdRol { get; set; }

        public virtual RolEmpleado IdRolNavigation { get; set; }
        //public virtual ICollection<RegistroFactura> RegistroFactura { get; set; }
    }
}
