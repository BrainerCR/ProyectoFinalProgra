using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryRegistroFactura : IRepository<data.RegistroFactura>
    {
        Task<IEnumerable<data.RegistroFactura>> GetAllWithAsAsync();
        Task<data.RegistroFactura> GetOneByIdAsAsync(int id);
    }
}
