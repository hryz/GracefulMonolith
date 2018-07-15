using Application.Customers.Commands;
using FluentValidation;

namespace Application.Customers.Validators
{
    public class MoveCustomerValidator : AbstractValidator<MoveCustomer>
    {
        public MoveCustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();

            RuleFor(x => x.CountryCode).NotEmpty().Length(2);
            RuleFor(x => x.ZipCode).InclusiveBetween(1, 999_999);
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.House).NotEmpty();
            RuleFor(x => x.Apartment).NotEmpty();
        }
    }
}
