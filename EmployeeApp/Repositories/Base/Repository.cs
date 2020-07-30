using EmployeeApp.Data;
using EmployeeApp.Models;
using EmployeeApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Repositories.Base
{
    public abstract class Repository<TEntity>
    {
        protected readonly DataContext _ctx;
        public Repository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Save()
        {
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
