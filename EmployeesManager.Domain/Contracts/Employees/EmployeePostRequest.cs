using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Domain.Contracts.Employees
{
    public class EmployeePostRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PlateNumber { get; set; }
        public Guid? LeaderId { get; set; }
    }
}
