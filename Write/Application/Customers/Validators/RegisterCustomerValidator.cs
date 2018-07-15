using Application.Customers.Commands;
using FluentValidation;

namespace Application.Customers.Validators
{
    public class RegisterCustomerValidator : AbstractValidator<RegisterCustomer>
    {
        public RegisterCustomerValidator()
        {
            RuleFor(x => x.CountryCode).NotEmpty().Length(2);
            RuleFor(x => x.ZipCode).InclusiveBetween(1, 999_999);
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.House).NotEmpty();
            RuleFor(x => x.Apartment).NotEmpty();

            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(150);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(150);
        }
    }
}
