using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Exceptions
{
    [Serializable]
    public class CeoSuperiorException : Exception
    {
        public CeoSuperiorException() : base(string.Format("The CEO cannot have a superior!"))
        {

        }
    }
}
