using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace EmployeesManager.Domain.Entities.Employees
{
    public class Employee : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PlateNumber { get; set; }
        public Guid LeaderId { get; set; }
        public Leader Leader { get; set; }
        public ICollection<Contact> Contacts { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
