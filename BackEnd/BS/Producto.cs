using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Producto : ICRUD<data.Producto>
    {
        private DBContext context;

        public Producto(DBContext _context)
        {
            context = _context;
        }

        public void Delete(data.Producto t)
        {
            new DAL.Producto(context).Delete(t);
        }

        public IEnumerable<data.Producto> GetAll()
        {
            return new DAL.Producto(context).GetAll();
        }

        public async Task<IEnumerable<data.Producto>> GetAllWithAsync()
        {
            return await new DAL.Producto(context).GetAllWithAsync();
        }

        public data.Producto GetOneByID(int id)
        {
            return new DAL.Producto(context).GetOneByID(id);
        }

        public async Task<data.Producto> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Producto(context).GetOneByIdWithAsync(id);
        }

        public void Insert(data.Producto t)
        {
            new DAL.Producto(context).Insert(t);
        }

        public void Update(data.Producto t)
        {
            new DAL.Producto(context).Update(t);
        }
    }
}
