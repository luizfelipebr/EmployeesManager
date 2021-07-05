using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeesManager.Infra.CrossCutting.IoC.DependencyInjection
{
    public static class StartupMethodsExtensions
    {
        public static IServiceCollection AddControllersConfig(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();
            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            assemblies = assemblies.Where(a => a.GetName().Name.StartsWith("EmployeesAdmin.Domain")).ToArray();
            return services.AddAutoMapper(assemblies);
        }
    }
}
