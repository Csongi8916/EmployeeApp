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
        static readonly Dictionary<WorkRole, string> WorkRoleTitles;

        static WorkRoleExtensions() {
            WorkRoleTitles = new Dictionary<WorkRole, string>();
            WorkRoleTitles.Add(WorkRole.HumanResourceManager, "HR munkatárs");
            WorkRoleTitles.Add(WorkRole.OfficeAssistant, "Irodai munkatárs");
            WorkRoleTitles.Add(WorkRole.SoftwareTester, "Szoftvertesztelő");
            WorkRoleTitles.Add(WorkRole.SoftwareEngineer, "Szoftverfejlesztő");
            WorkRoleTitles.Add(WorkRole.TeamLeader, "Fejlesztési vezető");
            WorkRoleTitles.Add(WorkRole.BusinessAnalyst, "Üzleti elemző");
            WorkRoleTitles.Add(WorkRole.ProjectManager, "Projekt menedzser");
            WorkRoleTitles.Add(WorkRole.CEO, "Ügyvezető igazgató");
        }

        public static string GetTitleFromWorkRole(this WorkRole workRole)
        {
            return WorkRoleTitles[workRole];
        }

        public static WorkRole GetWorkRoleFromTitle(this string title)
        {
            return WorkRoleTitles.FirstOrDefault(x => x.Value == title).Key;
        }
    }
}
