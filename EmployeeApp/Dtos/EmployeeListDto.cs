using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Dtos
{
    public class EmployeeListDto
    {
        public string Name { get; set; }
        public string WorkRole { get; set; }
        public string PhoneNumber { get; set; }
        public string OrganizationUnit { get; set; }
    }
}
