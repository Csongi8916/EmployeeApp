using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Helpers
{
    public class EmployeeParams
    {
        public readonly string[] OperationStatus = { "get", "create", "edit" };

        public readonly int GetOperationIndex = 0;
        public readonly int CreateOperationIndex = 1;
        public readonly int EditOperationIndex = 2;

        public string Mode { get; set; }
    }
}
