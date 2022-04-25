using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Servicios
{
    public interface IVinculoProductoServicio
    {
        void Insert(VinculoProducto t);
        void Update(VinculoProducto t);
        void Delete(VinculoProducto t);
        IEnumerable<VinculoProducto> GetAll();
        VinculoProducto GetOneById(int id);
        Task<IEnumerable<VinculoProducto>> GetAllAsync();
        Task<VinculoProducto> GetOneByIdAsync(int id);
    }
}
