using EmployeesManager.Domain.Contracts.Employees;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeResponse> CreateEmployee(EmployeePostRequest request);
        Task<EmployeeResponse> UpdateEmployee(Guid id, EmployeePutRequest request);
        List<EmployeeResponse> GetAllEmployees(EmployeeRequestFilter filter);
        bool DeleteEmployee(Guid id);
    }
}
