using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataModels
{
    public class RolEmpleado
    {
        //public RolEmpleado()
        //{
        //    Empleado = new HashSet<Empleado>();
        //}

        public int IdRol { get; set; }
        public string NombreRol { get; set; }

        //public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
