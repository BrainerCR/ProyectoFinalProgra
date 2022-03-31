﻿using DAL.DO.Objects;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public class RepositoryEmpleado : Repository<data.Empleado>, IRepositoryEmpleado
    {
        public RepositoryEmpleado(NDbContex context) : base(context)
        {

        }

        public async Task<IEnumerable<Empleado>> GetAllWithAsAsync()
        {
            return await _db.Empleado
                .Include(m => m.IdRolNavigation)
                .ToListAsync();
        }

        public async Task<Empleado> GetOneByIdAsAsync(int id)
        {
            return await _db.Empleado
               .Include(m => m.IdRolNavigation)
               .SingleOrDefaultAsync(m => m.IdEmpleado == id);
        }

        private NDbContex _db
        {
            get { return dbContext as NDbContex; }
        }
    }
}
