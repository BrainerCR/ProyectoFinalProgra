using DAL.DO.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace BS
{
    public class Cliente : ICRUD<data.Cliente>
    {
        private DBContext context;

        public Cliente(DBContext _context)
        {
            context = _context;
        }

        public void Delete(data.Cliente t)
        {
            new DAL.Cliente(context).Delete(t);
        }

        public IEnumerable<data.Cliente> GetAll()
        {
            return new DAL.Cliente(context).GetAll();
        }

        public async Task<IEnumerable<data.Cliente>> GetAllWithAsync()
        {
            return await new DAL.Cliente(context).GetAllWithAsync();
        }

        public data.Cliente GetOneByID(int id)
        {
            return new DAL.Cliente(context).GetOneByID(id);
        }

        public Task<data.Cliente> GetOneByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Cliente t)
        {
            new DAL.Cliente(context).Insert(t);
        }

        public void Update(data.Cliente t)
        {
            new DAL.Cliente(context).Update(t);
        }

        //private dal.Cliente _dal;
        //public Cliente(DBContext dbContext)
        //{
        //    _dal = new dal.Cliente(dbContext);
        //}


    }
}
