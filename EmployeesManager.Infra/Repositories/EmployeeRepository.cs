using EmployeesManager.Domain.Entities.Employees;
using EmployeesManager.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesManager.Infra.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeesManagerDBContext context) : base(context)
        {
        }

        public List<Employee> GetAllEmployeesByLeader(Guid leaderId)
        {
            return DbSet?
                .Where(emp => emp.LeaderId == leaderId)
                .OrderBy(u => u.GetFullName()).ToList();
        }

        public Employee GetByEmail(string email)
        {
            return DbSet.FirstOrDefault(emp => emp.User.Email == email);
        }

        public Employee GetByPlateNumber(int plateNumber)
        {
            return DbSet?
                .SingleOrDefault(user => user.PlateNumber == plateNumber);
        }
    }
}
