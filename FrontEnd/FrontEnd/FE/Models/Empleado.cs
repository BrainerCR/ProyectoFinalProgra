using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FE.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            RegistroFactura = new HashSet<RegistroFactura>();
        }

        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la cédula del empleado")]
        [DisplayName("Cédula")]
        public int CedulaEmpleado { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el nombre del empleado")]
        [DisplayName("Nombre")]
        public string NombreEmpleado { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el apellido del empleado")]
        [DisplayName("Apellido")]
        public string ApellidoEmpleado { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el correo del empleado")]
        [DisplayName("Correo")]
        [DataType(DataType.EmailAddress)]
        public string CorreoEmpleado { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese la contraseña del empleado")]
        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        public string ClaveEmpleado { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la provincia del empleado")]
        [DisplayName("Provincia")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el número telefónico del empleado")]
        [DisplayName("Contacto")]
        public string TelefonoEmpleado { get; set; }

        [Required(ErrorMessage = "Por favor seleccione el rol del empleado")]
        [DisplayName("Rol")]
        public int IdRol { get; set; }

        [DisplayName("Rol")]
        public virtual RolEmpleado IdRolNavigation { get; set; }
        public virtual ICollection<RegistroFactura> RegistroFactura { get; set; }
    }
}
