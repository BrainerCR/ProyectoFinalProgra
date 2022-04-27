using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FE.Models
{
    public partial class RolEmpleado
    {
        public RolEmpleado()
        {
            Empleado = new HashSet<Empleado>();
        }

        public int IdRol { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el nombre del rol")]
        [DisplayName("Nombre")]
        public string NombreRol { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
