using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class VinculoProducto : ICRUD<data.VinculoProducto>
    {
        private DBContext context;

        public VinculoProducto(DBContext _context)
        {
            context = _context;
        }

        public void Delete(data.VinculoProducto t)
        {
            new DAL.VinculoProducto(context).Delete(t);
        }

        public IEnumerable<data.VinculoProducto> GetAll()
        {
            return new DAL.VinculoProducto(context).GetAll();
        }

        public async Task<IEnumerable<data.VinculoProducto>> GetAllWithAsync()
        {
            return await new DAL.VinculoProducto(context).GetAllWithAsync();
        }

        public data.VinculoProducto GetOneByID(int id)
        {
            return new DAL.VinculoProducto(context).GetOneByID(id);
        }

        public Task<data.VinculoProducto> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.VinculoProducto t)
        {
            new DAL.VinculoProducto(context).Insert(t);
        }

        public void Update(data.VinculoProducto t)
        {
            new DAL.VinculoProducto(context).Update(t);
        }
    }
}
