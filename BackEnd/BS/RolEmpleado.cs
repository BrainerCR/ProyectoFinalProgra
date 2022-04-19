using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace BS
{
    public class RolEmpleado : ICRUD<data.RolEmpleado>
    {
        private DBContext context;

        public RolEmpleado(DBContext _context)
        {
            context = _context;
        }

        public void Delete(data.RolEmpleado t)
        {
            new DAL.RolEmpleado(context).Delete(t);
        }

        public IEnumerable<data.RolEmpleado> GetAll()
        {
            return new DAL.RolEmpleado(context).GetAll();
        }

        public async Task<IEnumerable<data.RolEmpleado>> GetAllWithAsync()
        {
            return await new DAL.RolEmpleado(context).GetAllWithAsync();
        }

        public data.RolEmpleado GetOneByID(int id)
        {
            return new DAL.RolEmpleado(context).GetOneByID(id);
        }

        public Task<data.RolEmpleado> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.RolEmpleado t)
        {
            new DAL.RolEmpleado(context).Insert(t);
        }

        public void Update(data.RolEmpleado t)
        {
            new DAL.RolEmpleado(context).Update(t);
        }
    }
}
