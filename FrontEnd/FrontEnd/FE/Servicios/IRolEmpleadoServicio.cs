using FE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Servicios
{
    public interface IRolEmpleadoServicio
    {
        void Insert(RolEmpleado t);
        void Update(RolEmpleado t);
        void Delete(RolEmpleado t);
        IEnumerable<RolEmpleado> GetAll();
        RolEmpleado GetOneById(int id);
        Task<IEnumerable<RolEmpleado>> GetAllAsync();
        Task<RolEmpleado> GetOneByIdAsync(int id);
    }
}
