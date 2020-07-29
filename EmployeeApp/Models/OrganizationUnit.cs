using EmployeeApp.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class OrganizationUnit : Entity
    {
        public OrganizationUnit()
        {
            Employees = new List<Employee>();
        }

        public string Abbreviation { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
