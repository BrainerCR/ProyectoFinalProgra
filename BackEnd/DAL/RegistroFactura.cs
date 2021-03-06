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
    public class RegistroFactura : ICRUD<data.RegistroFactura>
    {
        private RepositoryRegistroFactura _repo = null;

        public RegistroFactura(DBContext context)
        {
            _repo = new RepositoryRegistroFactura(context);
        }

        public void Delete(data.RegistroFactura t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.RegistroFactura> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.RegistroFactura>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public data.RegistroFactura GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public async Task<data.RegistroFactura> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdAsAsync(id);
        }

        public void Insert(data.RegistroFactura t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.RegistroFactura t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
