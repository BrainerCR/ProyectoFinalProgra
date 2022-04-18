using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public partial class Empleado
    {
        public Empleado()
        {
            //Descomentar hasta que se haga dicha clase
            RegistroFactura = new HashSet<RegistroFactura>();
        }

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
        public virtual ICollection<RegistroFactura> RegistroFactura { get; set; }
    }
}
