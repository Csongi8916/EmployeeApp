using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Dtos
{
    public class EmployeeDetailDto
    {
        public int Identification { get; set; }
        public string WorkRole { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }

        public string Superior { get; set; }
        public string OrganizationUnit { get; set; }
        public string OrganizationUnitAbbreviation { get; set; }
    }
}
