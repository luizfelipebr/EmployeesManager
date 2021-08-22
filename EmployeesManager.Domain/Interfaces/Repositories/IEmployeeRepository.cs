using EmployeesManager.Domain.Entities.Employees;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesManager.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee GetByEmail(string email);
        Employee GetByPlateNumber(int plateNumber);
        List<Employee> GetAllEmployeesByLeader(Guid leaderId);
    }
}
