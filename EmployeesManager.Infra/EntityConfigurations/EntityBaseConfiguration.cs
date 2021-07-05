using EmployeesManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeesManager.Infra.EntityConfigurations
{
    public abstract class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase<T>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
