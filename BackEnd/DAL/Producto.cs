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
    public class Producto : ICRUD<data.Producto>
    {
        private RepositoryProducto _repo = null;

        public Producto(DBContext context)
        {
            _repo = new RepositoryProducto(context);
        }

        public void Delete(data.Producto t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Producto> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Producto>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public data.Producto GetOneByID(int id)
        {
            return _repo.GetOneById(id);
        }

        public async Task<data.Producto> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetOneByIdAsAsync(id);
        }

        public void Insert(data.Producto t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Producto t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
