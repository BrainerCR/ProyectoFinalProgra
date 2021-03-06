using DAL.DO.Objects;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public class RepositoryRegistroFactura : Repository<data.RegistroFactura>, IRepositoryRegistroFactura
    {
        public RepositoryRegistroFactura(DBContext context) : base(context)
        {

        }

        public async Task<IEnumerable<RegistroFactura>> GetAllWithAsAsync()
        {
            return await _db.RegistroFactura
                .Include(m => m.IdClienteNavigation)
                .Include(m => m.IdEmpleadoNavigation)
                .ToListAsync();
        }

        public async Task<RegistroFactura> GetOneByIdAsAsync(int id)
        {
            return await _db.RegistroFactura
            .Include(m => m.IdClienteNavigation)
                .Include(m => m.IdEmpleadoNavigation)
               .SingleOrDefaultAsync(m => m.IdRegistro == id);
        }

        private DBContext _db
        {
            get { return dbContext as DBContext; }
        }
    }
}
