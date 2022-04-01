using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Distribuidor : ICRUD<data.Distribuidor>
    {
        private NDbContex context;

        public Distribuidor(NDbContex _context)
        {
            context = _context;
        }

        public void Delete(data.Distribuidor t)
        {
            new DAL.Distribuidor(context).Delete(t);
        }

        public IEnumerable<data.Distribuidor> GetAll()
        {
            return new DAL.Distribuidor(context).GetAll();
        }

        public async Task<IEnumerable<data.Distribuidor>> GetAllWithAsync()
        {
            return await new DAL.Distribuidor(context).GetAllWithAsync();
        }

        public data.Distribuidor GetOneByID(int id)
        {
            return new DAL.Distribuidor(context).GetOneByID(id);
        }

        public Task<data.Distribuidor> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Distribuidor t)
        {
            new DAL.Distribuidor(context).Insert(t);
        }

        public void Update(data.Distribuidor t)
        {
            new DAL.Distribuidor(context).Update(t);
        }
    }
}
