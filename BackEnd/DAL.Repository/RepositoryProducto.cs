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
    public class RepositoryProducto : Repository<data.Producto>, IRepositoryProducto
    {
        public RepositoryProducto(DBContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Producto>> GetAllWithAsAsync()
        {
            return await _db.Producto
                .Include(m => m.IdVinculoProductoNavigation)
                .Include(m => m.IdDistribuidorNavigation)
                .ToListAsync();
        }

        public async Task<Producto> GetOneByIdAsAsync(int id)
        {
            return await _db.Producto
               .Include(m => m.IdVinculoProductoNavigation)
               .Include(m => m.IdDistribuidorNavigation)
               .SingleOrDefaultAsync(m => m.IdProducto == id);
        }

        private DBContext _db
        {
            get { return dbContext as DBContext; }
        }
    }
}