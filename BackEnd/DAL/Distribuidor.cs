using DAL.DO.Interfaces;
using DAL.DO.Objects;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL
{
    public class Proveedor : ICRUD<data.Distribuidor>
    {
        private Repository<data.Distribuidor> _repo = null;

        public Proveedor(NDbContex DbContext)
        {
            _repo = new Repository<data.Distribuidor>(DbContext);
        }

        public void Delete(Distribuidor t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<Distribuidor> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<Distribuidor>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public Distribuidor GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public Task<Distribuidor> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Distribuidor t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(Distribuidor t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
