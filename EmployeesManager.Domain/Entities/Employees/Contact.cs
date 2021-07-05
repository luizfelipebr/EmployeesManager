using EmployeesManager.Domain.Enums;
using FluentValidation;
using System;

namespace EmployeesManager.Domain.Entities.Employees
{
    public class Contact : EntityBase<Contact>
    {
        public string Content { get; set; }
        public EContactType ContactType { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public override bool IsValid()
        {
            ValidateFields();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }

        public void ValidateFields()
        {
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.ContactType).IsInEnum();
            RuleFor(x => x.Content)
                .Matches(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$")
                .When(x => x.ContactType == EContactType.PhoneNumber);
        }
    }
}
