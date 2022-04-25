using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Servicios
{
    public interface IDistribuidorServicio
    {
        void Insert(Distribuidor t);
        void Update(Distribuidor t);
        void Delete(Distribuidor t);
        IEnumerable<Distribuidor> GetAll();
        Distribuidor GetOneById(int id);
        Task<IEnumerable<Distribuidor>> GetAllAsync();
        Task<Distribuidor> GetOneByIdAsync(int id);
    }
}
