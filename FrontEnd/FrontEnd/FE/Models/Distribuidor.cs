using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FE.Models
{
    public partial class Distribuidor
    {
        public Distribuidor()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdDistribuidor { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la cédula del distribuidor")]
        [DisplayName("Cédula")]
        public int CedulaDistribuidor { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la fecha de ingreso del distribuidor")]
        [DisplayName("Fecha Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el nombre del distribuidor")]
        [DisplayName("Nombre")]
        public string NombreDistribuidor { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el correo del distribuidor")]
        [DisplayName("Correo")]
        [DataType(DataType.EmailAddress)]
        public string CorreoDistribuidor { get; set; }

        [Required(ErrorMessage = "Por favor ingrese la provincia del distribuidor")]
        [DisplayName("Provincia")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "Por favor ingrese el número telefónico del distribuidor")]
        [DisplayName("Contacto")]
        public string TelefonoDistribuidor { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
