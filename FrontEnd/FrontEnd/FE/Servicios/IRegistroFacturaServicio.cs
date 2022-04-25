using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Servicios
{
    public interface IRegistroFacturaServicio
    {
        void Insert(RegistroFactura t);
        void Update(RegistroFactura t);
        void Delete(RegistroFactura t);
        IEnumerable<RegistroFactura> GetAll();
        RegistroFactura GetOneById(int id);
        Task<IEnumerable<RegistroFactura>> GetAllAsync();
        Task<RegistroFactura> GetOneByIdAsync(int id);
    }
}
