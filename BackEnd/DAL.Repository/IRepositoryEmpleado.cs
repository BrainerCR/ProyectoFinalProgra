using System.Collections.Generic;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryEmpleado : IRepository<data.Empleado>
    {
        Task<IEnumerable<data.Empleado>> GetAllWithAsAsync();
        Task<data.Empleado> GetOneByIdAsAsync(int id);
    }
}
