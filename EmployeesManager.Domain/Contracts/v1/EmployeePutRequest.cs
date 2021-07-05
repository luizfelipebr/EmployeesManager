using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Domain.Contracts.v1
{
    public class EmployeePutRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PlateNumber { get; set; }
        public Guid LeaderId { get; set; }
    }
}
