using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using data = DAL.DO.Objects;

namespace DAL
{
    public class Cliente : ICRUD<data.Cliente>
    {
        private Repository<data.Cliente> _repo = null;

        public Cliente(NDbContex context)
        {
            _repo = new Repository<data.Cliente>(context);
        }

        public void Delete(data.Cliente t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Cliente> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.Cliente>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Cliente GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public Task<data.Cliente> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Cliente t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Cliente t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
