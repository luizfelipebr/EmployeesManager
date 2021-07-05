using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Domain.Contracts.v1
{
    public class EmployeeRequestFilter
    {
        public Guid? LeaderId { get; set; }
    }
}
