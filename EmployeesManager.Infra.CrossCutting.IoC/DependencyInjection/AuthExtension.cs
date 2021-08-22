using EmployeesManager.Domain.Entities.Accounts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesManager.Infra.CrossCutting.IoC.DependencyInjection
{
    public static class AuthExtension
    {
        public static IServiceCollection AddAuth(
            this IServiceCollection services
        )
        {
            services.AddIdentityCore<User>()
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
