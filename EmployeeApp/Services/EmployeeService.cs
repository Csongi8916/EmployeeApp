using EmployeeApp.Models;
using EmployeeApp.Repositories;
using EmployeeApp.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeApp.Services
{
    public class EmployeeService : ILogicService<Employee>
    {
        private readonly EmployeeRepository _repo;
        public EmployeeService(EmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            await _repo.DbSet.AddAsync(employee);
            await _repo.Save();
            return employee;
        }

        public async Task DeleteAsync(Employee employee)
        {
            var result = await _repo.DbSet.FindAsync(employee);
            result.Active = false;
            await _repo.Save();
        }

        public async Task<Employee> GetByIdAsync(long id)
        {
            return await _repo.DbSet.SingleOrDefaultAsync(e => e.Id == id && e.Active);
        }

        public async Task<IQueryable<Employee>> Query(Expression<Func<Employee, bool>> predicate)
        {
            var employees = await _repo.DbSet.Where(predicate).ToListAsync();
            return employees.AsQueryable();
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            var result = await _repo.DbSet.FindAsync(employee);
            // TODO Mapping
            await _repo.Save();
            return employee;
        }
    }
}
