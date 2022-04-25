using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Servicios
{
    public interface IProductoServicio
    {
        void Insert(Producto t);
        void Update(Producto t);
        void Delete(Producto t);
        IEnumerable<Producto> GetAll();
        Producto GetOneById(int id);
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto> GetOneByIdAsync(int id);
    }
}
