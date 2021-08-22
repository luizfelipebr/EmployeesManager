using System;

namespace EmployeesManager.Domain.Contracts.Accounts
{
    public class UserCreateResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
