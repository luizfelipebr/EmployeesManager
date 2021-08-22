using EmployeesManager.Domain.Entities.Employees;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesManager.Infra.CrossCutting.IoC.DependencyInjection
{
    public static class AuthExtension
    {
        public static IServiceCollection AddAuth(
            this IServiceCollection services
        )
        {
            services.AddIdentityCore<Employee>()
                .AddEntityFrameworkStores<EmployeesManagerDBContext>();

            return services;
        }

        public static IApplicationBuilder UseAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            return app;
        }
    }
}
