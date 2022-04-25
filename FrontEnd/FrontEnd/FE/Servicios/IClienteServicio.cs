using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Servicios
{
    public interface IClienteServicio
    {
        void Insert(Cliente t);
        void Update(Cliente t);
        void Delete(Cliente t);
        IEnumerable<Cliente> GetAll();
        Cliente GetOneById(int id);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetOneByIdAsync(int id);
    }
}
