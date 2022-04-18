using System.Collections.Generic;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryProducto : IRepository<data.Producto>
    {
        Task<IEnumerable<data.Producto>> GetAllWithAsAsync();
        Task<data.Producto> GetOneByIdAsAsync(int id);
    }
}
