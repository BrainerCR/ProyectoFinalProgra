using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL
{
    public class VinculoProducto : ICRUD<data.VinculoProducto>
    {
        private Repository<data.VinculoProducto> _repo = null;

        public VinculoProducto(NDbContex DbContext)
        {
            _repo = new Repository<data.VinculoProducto>(DbContext);
        }

        public void Delete(data.VinculoProducto t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.VinculoProducto> GetAll()
        {
            return _repo.GetAll();
        }

        public Task<IEnumerable<data.VinculoProducto>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.VinculoProducto GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public Task<data.VinculoProducto> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.VinculoProducto t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.VinculoProducto t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
