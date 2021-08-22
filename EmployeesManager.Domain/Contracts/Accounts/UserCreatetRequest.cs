using System;

namespace EmployeesManager.Domain.Contracts.Accounts
{
    public class UserCreatetRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
