using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdProveedor { get; set; }
        public int CedulaProveedor { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NombreProveedor { get; set; }
        public string CorreoProveedor { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string TelefonoProveedor { get; set; }
        public string CuentaBancariaProveedor { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
