using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models.Interfaces
{
    public interface IEntity
    {
        long Id { get; set; }
        string Name { get; set; }
        bool Active { get; set; }
    }
}
