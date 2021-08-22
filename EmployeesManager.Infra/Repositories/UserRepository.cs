using EmployeesManager.Domain.Entities.Accounts;
using EmployeesManager.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManager.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(
            UserManager<User> userManager
        )
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Add(User user, string password)
        {
            if (user.Email != user.UserName) user.UserName = user.Email;
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

        public IList<User> GetAll()
        {
            return _userManager.Users?.OrderBy(u => u.Email).ToList();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<User> GetById(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<IdentityResult> Update(User user)
        {
            return await _userManager.UpdateAsync(user);
        }
        private void Dispose(bool status)
        {
            if (!status) return;
        }
    }
}
