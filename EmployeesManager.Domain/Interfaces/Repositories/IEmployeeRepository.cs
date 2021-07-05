using EmployeesManager.Domain.Entities.Employees;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesManager.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository : IDisposable
    {
        Task<IdentityResult> Add(Employee user, string password);
        Task<IdentityResult> Update(Employee user);
        Task<IdentityResult> Delete(Guid id);
        Task<Employee> GetById(Guid id);
        Task<Employee> GetByEmail(string email);
        IList<Employee> GetAll();
        Employee GetByPlateNumber(int plateNumber);
        List<Employee> GetAllEmployeesByLeader(Guid leaderId);
    }
}
