using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Exceptions
{
    [Serializable]
    public class InvalidWorkRoleException : Exception
    {
        public InvalidWorkRoleException()
        {

        }

        public InvalidWorkRoleException(string name)
            : base(string.Format("Invalid WorkRole: {0}", name))
        {

        }
    }
}
