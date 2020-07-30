using EmployeeApp.Exceptions;
using EmployeeApp.Models;
using EmployeeApp.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Data
{
    public class SeedSubalterns
    {
        public static void RunSeeds(DataContext ctx)
        {
            foreach (var employeeItem in ctx.Employees.Include(e => e.Subalterns))
            {
                if (employeeItem.WorkRole != WorkRole.CEO)
                {
                    var superior = GetSuperior(ctx, employeeItem.WorkRole);
                    superior.Subalterns.Add(employeeItem);
                }
            }
            ctx.SaveChanges();
        }

        private static Employee GetSuperior(DataContext ctx, WorkRole workRole)
        {
            if (WorkRole.BusinessAnalyst == workRole
                || WorkRole.TeamLeader == workRole
                || WorkRole.HumanResourceManager == workRole
                || WorkRole.ProjectManager == workRole
                || WorkRole.OfficeAssistant == workRole)
            {
                return ctx.Employees.SingleOrDefault(e => e.WorkRole == WorkRole.CEO);
            }
            else if (WorkRole.SoftwareTester == workRole
                || WorkRole.SoftwareEngineer == workRole)
            {
                return ctx.Employees.SingleOrDefault(e => e.WorkRole == WorkRole.TeamLeader);
            }
            else if (WorkRole.CEO == workRole)
            {
                throw new CeoSuperiorException();
            }

            throw new InvalidWorkRoleException(workRole.ToString());

        }
    }
}
