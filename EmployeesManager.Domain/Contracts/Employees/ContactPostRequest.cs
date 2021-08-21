using EmployeesManager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Domain.Contracts.Employees
{
    public class ContactPostRequest
    {
        public string Content { get; set; }
        public EContactType ContactType { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
