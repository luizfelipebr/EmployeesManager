using EmployeesManager.Domain.Entities.Employees;
using EmployeesManager.Infra.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeesManager.Infra
{
    public class EmployeesAdminContext : IdentityDbContext<Employee, CustomRole, Guid>
    {
        public DbSet<Contact> Contacts { get; set; }

        public EmployeesAdminContext(DbContextOptions<EmployeesAdminContext> options) : base(options) { }

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
