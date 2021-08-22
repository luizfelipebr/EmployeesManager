using EmployeesManager.Domain.Entities.Accounts;
using EmployeesManager.Domain.Entities.Employees;
using EmployeesManager.Infra.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeesManager.Infra
{
    public class EmployeesManagerDBContext : IdentityDbContext<User, CustomRole, Guid>
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeesManagerDBContext(DbContextOptions<EmployeesManagerDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyConfigurations(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ContractConfiguration());
            modelBuilder.ApplyConfiguration(new LeaderConfiguration());
        }
    }
}
