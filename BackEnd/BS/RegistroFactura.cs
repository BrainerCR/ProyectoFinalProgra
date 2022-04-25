using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class RegistroFactura : ICRUD<data.RegistroFactura>
    {
        private DBContext context;

        public RegistroFactura(DBContext _context)
        {
            context = _context;
        }

        public void Delete(data.RegistroFactura t)
        {
            new DAL.RegistroFactura(context).Delete(t);
        }

        public IEnumerable<data.RegistroFactura> GetAll()
        {
            return new DAL.RegistroFactura(context).GetAll();
        }

        public async Task<IEnumerable<data.RegistroFactura>> GetAllWithAsync()
        {
            return await new DAL.RegistroFactura(context).GetAllWithAsync();
        }

        public data.RegistroFactura GetOneByID(int id)
        {
            return new DAL.RegistroFactura(context).GetOneByID(id);
        }

        public async Task<data.RegistroFactura> GetOneByIdWithAsync(int id)
        {
            return await new DAL.RegistroFactura(context).GetOneByIdWithAsync(id);
        }

        public void Insert(data.RegistroFactura t)
        {
            new DAL.RegistroFactura(context).Insert(t);
        }

        public void Update(data.RegistroFactura t)
        {
            new DAL.RegistroFactura(context).Update(t);
        }
    }
}
