using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FE.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            RegistroFactura = new HashSet<RegistroFactura>();
        }

        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la cédula del cliente")]
        [DisplayName("Cédula")]
        public int CedulaCliente { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la fecha de ingreso")]
        [DisplayName("Fecha Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el nombre del cliente")]
        [DisplayName("Nombre")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el correo del cliente")]
        [DisplayName("Correo")]
        [DataType(DataType.EmailAddress)]
        public string CorreoEmpleado { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la provincia del cliente")]
        [DisplayName("Provincia")]
        public string Provincia { get; set; }

        public virtual ICollection<RegistroFactura> RegistroFactura { get; set; }
    }
}
