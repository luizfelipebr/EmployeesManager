using EmployeesManager.Domain.Entities.Employees;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Domain.Entities.Accounts
{
    public class User : IdentityUser<Guid>
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
