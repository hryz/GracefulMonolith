using Application.Customers.Commands;
using FluentValidation;

namespace Application.Customers.Validators
{
    public class EnableCustomerValidator : AbstractValidator<EnableCustomer>
    {
        public EnableCustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
        }
    }
}
