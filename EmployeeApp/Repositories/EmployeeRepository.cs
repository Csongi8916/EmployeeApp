using EmployeeApp.Data;
using EmployeeApp.Models;
using EmployeeApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DataContext ctx) : base(ctx)
        {
        }

        public DbSet<Employee> DbSet => _ctx.Employees;
    }
}
