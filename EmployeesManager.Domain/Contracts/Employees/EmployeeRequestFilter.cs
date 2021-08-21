using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Domain.Contracts.Employees
{
    public class EmployeeRequestFilter
    {
        public Guid? LeaderId { get; set; }
    }
}
