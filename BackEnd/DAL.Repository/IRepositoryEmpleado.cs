using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    interface IRepositoryEmpleado
    {
        public interface IRepositoryEmpleado : IRepository<data.Empleado>
        {
            Task<IEnumerable<data.Empleado>> GetAllWithAsAsync();
            Task<data.Empleado> GetOneByIdAsAsync(int id);
        }
    }
}
