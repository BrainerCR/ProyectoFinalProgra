using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
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
