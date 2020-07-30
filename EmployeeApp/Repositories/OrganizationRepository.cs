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
    public class OrganizationRepository : Repository<OrganizationUnit>, IOrganizationRepository
    {
        public OrganizationRepository(DataContext ctx) : base(ctx)
        {
        }

        public DbSet<OrganizationUnit> DbSet => _ctx.OrganizationUnits;
    }
}
