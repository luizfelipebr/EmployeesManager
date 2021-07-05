using EmployeesManager.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Infra.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired();

            builder.Property(e => e.LastName)
                .IsRequired();

            builder.Property(e => e.Email)
                .IsRequired();

            builder.Property(e => e.PlateNumber)
                .IsRequired();

            builder.HasIndex(e => e.PlateNumber)
                .IsUnique();

            builder.HasOne(e => e.Leader)
                .WithMany(l => l.Employees)
                .OnDelete(DeleteBehavior.NoAction);

            builder.OwnsMany(e => e.Contacts)
                .WithOwner(c => c.Employee);
        }
    }
}
