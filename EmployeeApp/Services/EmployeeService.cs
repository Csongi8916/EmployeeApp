using EmployeeApp.Models;
using EmployeeApp.Repositories;
using EmployeeApp.Repositories.Base;
using EmployeeApp.Services.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IOrganizationRepository _organizationRepo;
        public EmployeeService(IEmployeeRepository employeeRepo, IOrganizationRepository organizationRepo)
        {
            _employeeRepo = employeeRepo;
            _organizationRepo = organizationRepo;
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            await _employeeRepo.DbSet.AddAsync(employee);
            var superior = await _employeeRepo.DbSet.SingleOrDefaultAsync(e => e.Id == employee.SuperiorId);
            superior.Subalterns.Add(employee);
            var organization = await _organizationRepo.DbSet.SingleOrDefaultAsync(o => o.Id == employee.OrganizationUnitId);
            organization.Employees.Add(employee);
            await _organizationRepo.Save();

            return employee;
        }

        public async Task DeleteAsync(Employee employee)
        {
            var result = await _employeeRepo.DbSet.Include(e => e.OrganizationUnit).SingleOrDefaultAsync(e => e.Id == employee.Id && e.Active);
            result.Active = false;
            await _employeeRepo.Save();
        }

        public async Task<Employee> GetByIdAsync(long id)
        {
            var employee = await _employeeRepo.DbSet.Include(e => e.OrganizationUnit).SingleOrDefaultAsync(e => e.Id == id && e.Active);
            return employee;
        }

        public async Task<IQueryable<Employee>> Query(Expression<Func<Employee, bool>> predicate)
        {
            var employees = await _employeeRepo.DbSet.Include(e => e.OrganizationUnit).Where(predicate).ToListAsync();
            return employees.AsQueryable();
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            var employeeEntity = await _employeeRepo.DbSet.SingleOrDefaultAsync(o => o.Id == employee.Id);
            employeeEntity = employee;
            var organization = await _organizationRepo.DbSet.SingleOrDefaultAsync(o => o.Id == employee.OrganizationUnitId);
            organization.Employees.Add(employee);
            await _employeeRepo.Save();

            return employee;
        }
    }
}
