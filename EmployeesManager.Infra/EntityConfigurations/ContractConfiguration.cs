using EmployeesManager.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EmployeesManager.Infra.EntityConfigurations
{
    public class ContractConfiguration : EntityBaseConfiguration<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            base.Configure(builder);
        }
    }
}
