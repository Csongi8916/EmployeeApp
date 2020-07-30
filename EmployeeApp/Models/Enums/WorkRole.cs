using EmployeeApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models.Enums
{
    public enum WorkRole
    {
        HumanResourceManager,
        OfficeAssistant,
        SoftwareTester,
        SoftwareEngineer,
        TeamLeader,
        BusinessAnalyst,
        ProjectManager,
        CEO,
    }

    static class WorkRoleExtensions
    {
        public static string GetWorkRoleTitle(this WorkRole workRole)
        {
            switch (workRole)
            {
                case WorkRole.HumanResourceManager: return "HR munkatárs";
                case WorkRole.OfficeAssistant: return "HR munkatárs";
                case WorkRole.SoftwareTester: return "HR munkatárs";
                case WorkRole.SoftwareEngineer: return "HR munkatárs";
                case WorkRole.TeamLeader: return "HR munkatárs";
                case WorkRole.BusinessAnalyst: return "HR munkatárs";
                case WorkRole.ProjectManager: return "HR munkatárs";
                case WorkRole.CEO: return "HR munkatárs";
                default: throw new InvalidWorkRoleException(workRole.ToString());
            }
        }
    }
}
