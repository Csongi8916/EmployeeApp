using EmployeeApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Helpers
{
    public interface IDataBuildHelper
    {
        Task GetAdditionalData(EmployeeEditDto sampleEmployeeEditDto);
    }
}
