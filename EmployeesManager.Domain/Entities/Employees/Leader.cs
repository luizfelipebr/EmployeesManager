using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Domain.Entities.Employees
{
    public class Leader : Employee
    {
        public ICollection<Employee> Employees { get; set; }
    }
}
