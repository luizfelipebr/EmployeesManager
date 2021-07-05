using EmployeesManager.Domain.Entities.Employees;
using EmployeesManager.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManager.Infra.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly UserManager<Employee> _userManager;

        public EmployeeRepository(
            UserManager<Employee> userManager
        )
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Add(Employee user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return await _userManager.DeleteAsync(user);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IList<Employee> GetAll()
        {
            return _userManager.Users?.OrderBy(u => u.GetFullName()).ToList();
        }

        public List<Employee> GetAllEmployeesByLeader(Guid leaderId)
        {
            return _userManager.Users?
                .Where(user => user.LeaderId == leaderId)
                .OrderBy(u => u.GetFullName()).ToList();
        }

        public async Task<Employee> GetByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<Employee> GetById(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public Employee GetByPlateNumber(int plateNumber)
        {
            return _userManager.Users?
                .SingleOrDefault(user => user.PlateNumber == plateNumber);
        }

        public async Task<IdentityResult> Update(Employee user)
        {
            return await _userManager.UpdateAsync(user);
        }
        private void Dispose(bool status)
        {
            if (!status) return;
        }
    }
}
