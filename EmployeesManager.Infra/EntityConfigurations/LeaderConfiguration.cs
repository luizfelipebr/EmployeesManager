using EmployeesManager.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManager.Infra.EntityConfigurations
{
    public class LeaderConfiguration : IEntityTypeConfiguration<Leader>
    {
        public void Configure(EntityTypeBuilder<Leader> builder)
        {
            builder.HasMany(l => l.Employees)
                .WithOne(e => e.Leader)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
