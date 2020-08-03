using EmployeeApp.Dtos;
using EmployeeApp.Helpers.Model;
using EmployeeApp.Models;
using EmployeeApp.Repositories.Base;
using EmployeeApp.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Helpers
{
    public class DataBuildHelper : IDataBuildHelper
    {
        private readonly IEmployeeService _employeeService;
        private readonly IOrganizationRepository _organizationRepo;
        public DataBuildHelper(IEmployeeService employeeService, IOrganizationRepository organizationRepo)
        {
            _employeeService = employeeService;
            _organizationRepo = organizationRepo;
        }

        public async Task GetAdditionalData(EmployeeEditDto employeeEditDto)
        {
            var employees = (await _employeeService.Query(e => e.Active)).ToList();
            List<SelectEntity> selectEmployees = GetData<Employee>(employees);
            employeeEditDto.Superiors = selectEmployees;

            var organizations = _organizationRepo.DbSet.Select(o => o).ToList();
            List<SelectEntity> selectOrganizazions = GetData<OrganizationUnit>(organizations);
            employeeEditDto.OrganizationUnits = selectOrganizazions;
        }

        private List<SelectEntity> GetData<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : Models.Interfaces.IEntity
        {
            List<SelectEntity> selectEntities = new List<SelectEntity>();
            
            foreach (var entity in entities)
            {
                selectEntities.Add(new SelectEntity() { Id = entity.Id, Name = entity.Name });
            }

            return selectEntities;
        }
    }
}
