using EmployeesManager.Domain.Entities.Accounts;
using EmployeesManager.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EmployeesManager.Application.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountsService(
            UserManager<User> userManager,
            IHttpContextAccessor httpContext
        )
        {
            _userManager = userManager;
            _httpContextAccessor = httpContext;
        }

        public User GetCurrentUser()
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = _userManager.FindByEmailAsync(userName).GetAwaiter().GetResult();

            return user;
        }

        public void CreateUser()
        {

        }
    }
}
