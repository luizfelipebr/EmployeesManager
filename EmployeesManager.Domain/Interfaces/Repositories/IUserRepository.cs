using EmployeesManager.Domain.Entities.Accounts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesManager.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IDisposable
    {
        Task<IdentityResult> Add(User user, string password);
        Task<IdentityResult> Update(User user);
        Task<IdentityResult> Delete(Guid id);
        Task<User> GetById(Guid id);
        Task<User> GetByEmail(string email);
        IList<User> GetAll();
    }
}
