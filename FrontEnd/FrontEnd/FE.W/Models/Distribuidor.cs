using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class Distribuidor
    {
        public Distribuidor()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdDistribuidor { get; set; }
        public int CedulaDistribuidor { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NombreDistribuidor { get; set; }
        public string CorreoDistribuidor { get; set; }
        public string Provincia { get; set; }
        public string TelefonoDistribuidor { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
