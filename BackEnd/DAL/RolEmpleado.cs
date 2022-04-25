using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL
{
    public class RolEmpleado : ICRUD<data.RolEmpleado>
    {
        private Repository<data.RolEmpleado> _repo = null;

        public RolEmpleado(DBContext context)
        {
            _repo = new Repository<data.RolEmpleado>(context);
        }
        public void Delete(data.RolEmpleado t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.RolEmpleado> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.RolEmpleado>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.RolEmpleado GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public Task<data.RolEmpleado> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.RolEmpleado t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.RolEmpleado t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
