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
            return services.AddDbContext<EmployeesManagerDBContext>(opt => opt.UseInMemoryDatabase("Database"));
        }

        public static IServiceCollection AddEmployeesRepositories(this IServiceCollection services)
        {
            return services
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<IEmployeeRepository, EmployeeRepository>()
                .AddSingleton<IContactRepository, ContactRepository>()
                .AddSingleton<IUnitOfWork, UnitOfWork>();
        }
    }
}
