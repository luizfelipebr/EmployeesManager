using EmployeesManager.Domain.Entities.Employees;
using EmployeesManager.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EmployeesManager.Application.Services
{
    public class HttpContextHelper : IHttpContextHelper
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextHelper(
            UserManager<Employee> userManager,
            IHttpContextAccessor httpContext
        )
        {
            _userManager = userManager;
            _httpContextAccessor = httpContext;
        }

        public Employee GetCurrentUser()
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = _userManager.FindByEmailAsync(userName).Result;

            return user;
        }
    }
}
