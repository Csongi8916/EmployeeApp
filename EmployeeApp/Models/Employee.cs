using EmployeeApp.Models.Bases;
using EmployeeApp.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class Employee : Entity
    {
        public int Identification { get; set; }
        public WorkRole WorkRole { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public long? SuperiorId { get; set; }
        public Employee Superior { get; set; }
        public ICollection<Employee> Subalterns { get; set; }
        public long OrganizationUnitId { get; set; }
        public OrganizationUnit OrganizationUnit { get; set; }
    }
}
