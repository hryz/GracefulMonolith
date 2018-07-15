using Data.Read.Customers.Queries;
using FluentValidation;

namespace Data.Read.Customers.Validators
{
    public class GetCustomerDetailsValidator : AbstractValidator<GetCustomerDetails>
    {
        public GetCustomerDetailsValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
