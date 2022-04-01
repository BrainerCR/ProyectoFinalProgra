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
    public class Distribuidor : ICRUD<data.Distribuidor>
    {
        private Repository<data.Distribuidor> _repo = null;

        public Distribuidor(NDbContex DbContext)
        {
            _repo = new Repository<data.Distribuidor>(DbContext);
        }

        public void Delete(data.Distribuidor t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Distribuidor> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Distribuidor>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Distribuidor GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public Task<data.Distribuidor> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Distribuidor t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Distribuidor t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
