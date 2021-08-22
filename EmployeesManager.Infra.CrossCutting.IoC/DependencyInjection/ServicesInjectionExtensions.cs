using EmployeesManager.Application.Services;
using EmployeesManager.Domain.Entities.Accounts;
using EmployeesManager.Domain.Entities.Employees;
using EmployeesManager.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EmployeesManager.Infra.CrossCutting.IoC.DependencyInjection
{
    public static class ServicesInjectionExtensions
    {
        public static IServiceCollection AddEmployeesServices(this IServiceCollection services)
        {
            services
            .AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }

        public static IServiceCollection AddAccountsServices(this IServiceCollection services)
        {
            services
            .AddHttpContextAccessor()
            .AddScoped<IAccountsService, AccountsService>()
            .AddIdentity<User, CustomRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
            .AddRoles<CustomRole>()
            .AddEntityFrameworkStores<EmployeesManagerDBContext>()
            .AddDefaultTokenProviders();
            return services;
        }
    }
}
