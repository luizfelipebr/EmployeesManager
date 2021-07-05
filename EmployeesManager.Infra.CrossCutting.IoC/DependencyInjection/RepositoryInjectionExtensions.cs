using EmployeesManager.Domain.Interfaces.Repositories;
using EmployeesManager.Infra.Repositories;
using EmployeesManager.Infra.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesManager.Infra.DependencyInjection.CrossCutting.IoC
{
    public static class RepositoryInjectionExtensions
    {
        public static IServiceCollection AddInMemoryContext(this IServiceCollection services)
        {
            return services.AddDbContext<EmployeesAdminContext>(opt => opt.UseInMemoryDatabase("Database"));
        }

        public static IServiceCollection AddEmployeesRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IContactRepository, ContactRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
