using Application.Customers.Commands;
using FluentValidation;

namespace Application.Customers.Validators
{
    public class DisableCustomerValidator : AbstractValidator<DisableCustomer>
    {
        public DisableCustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
        }
    }
}
