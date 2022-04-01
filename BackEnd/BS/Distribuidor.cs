using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
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
            throw new NotImplementedException();
        }

        public IEnumerable<data.Distribuidor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<data.Distribuidor>> GetAllWithAsync()
        {
            throw new NotImplementedException();
        }

        public data.Distribuidor GetOneByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<data.Distribuidor> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Distribuidor t)
        {
            throw new NotImplementedException();
        }

        public void Update(data.Distribuidor t)
        {
            throw new NotImplementedException();
        }
    }
}
