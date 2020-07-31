using EmployeeApp.Helpers;
using EmployeeApp.Helpers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Dtos
{
    public class EmployeeEditDto
    {
        public string Name { get; set; }
        public int Identification { get; set; }
        public string WorkRole { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public bool Active { get; set; }

        public long? SuperiorId { get; set; }
        public string Superior { get; set; }
        public long OrganizationUnitId { get; set; }
        public string OrganizationUnit { get; set; }
        public string OrganizationUnitAbbreviation { get; set; }

        public string[] WorkRoleTitles { get; set; }
        public IEnumerable<SelectEntity> Superiors { get; set; }
        public IEnumerable<SelectEntity> OrganizationUnits { get; set; }
    }
}
