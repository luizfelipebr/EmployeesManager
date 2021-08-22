using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Domain.Contracts.Employees
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PlateNumber { get; set; }
        public LeaderResponse Leader { get; set; }
    }

    public class LeaderResponse
    {
        public Guid? LeaderId { get; set; }
        public string FullName { get; set; }
        public LeaderResponse() { }
        public LeaderResponse(Guid? id, string fullName)
        {
            this.LeaderId = id;
            this.FullName = fullName;
        }
    }
}
