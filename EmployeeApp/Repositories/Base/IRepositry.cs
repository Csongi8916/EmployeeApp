using EmployeeApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Repositories.Base
{
    public interface IRepositry<TEntity>
        where TEntity : class
    {
        DbSet<TEntity> DbSet { get; }

        Task<bool> Save();
    }
}
