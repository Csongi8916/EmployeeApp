using EmployeeApp.Exceptions;
using EmployeeApp.Models;
using EmployeeApp.Models.Enums;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace EmployeeApp.Data
{
    public class Seed
    {
        public static void RunSeeds(DataContext ctx)
        {
            SeedOrganizationUnits(ctx);
            SeedEmployees(ctx);
        }

        public static void SeedOrganizationUnits(DataContext ctx)
        {
            if (!ctx.OrganizationUnits.Any())
            {
                var orgData = System.IO.File.ReadAllText("Data/org-data.json");
                var orgItems = JsonConvert.DeserializeObject<List<OrganizationUnit>>(orgData);
                foreach (var orgItem in orgItems)
                {
                    ctx.OrganizationUnits.Add(orgItem);
                }

                ctx.SaveChanges();
            }
        }

        public static void SeedEmployees(DataContext ctx)
        {
            if (!ctx.Employees.Any())
            {
                var employeeData = System.IO.File.ReadAllText("Data/emploee-data.json");
                var employeeItems = JsonConvert.DeserializeObject<List<Employee>>(employeeData);
                foreach (var employeeItem in employeeItems)
                {
                    var org = GetOrganizationUnit(ctx, employeeItem.WorkRole);
                    ctx.Employees.Add(employeeItem);
                    org.Employees.Add(employeeItem);
                }
                ctx.SaveChanges();
            }
        }

        private static OrganizationUnit GetOrganizationUnit(DataContext ctx, WorkRole workRole)
        {
            if (WorkRole.BusinessAnalyst == workRole
                || WorkRole.CEO == workRole
                || WorkRole.HumanResourceManager == workRole
                || WorkRole.ProjectManager == workRole)
            {
                return ctx.OrganizationUnits.SingleOrDefault(o => o.Abbreviation == "MGT");
            }
            else if (WorkRole.SoftwareTester == workRole
                || WorkRole.SoftwareEngineer == workRole
                || WorkRole.TeamLeader == workRole)
            {
                return ctx.OrganizationUnits.SingleOrDefault(o => o.Abbreviation == "IT");
            }
            else if (WorkRole.OfficeAssistant == workRole)
            {
                return ctx.OrganizationUnits.SingleOrDefault(o => o.Abbreviation == "BO");
            }

            throw new InvalidWorkRoleException(workRole.ToString());
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
