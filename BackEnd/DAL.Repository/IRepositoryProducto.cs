using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    interface IRepositoryProducto
    {
        public interface IRepositoryProducto : IRepository<data.Producto>
        {
            Task<IEnumerable<data.Producto>> GetAllWithAsAsync();
            Task<data.Producto> GetOneByIdAsAsync(int id);
        }
    }
}
