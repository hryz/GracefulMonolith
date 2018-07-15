using System;
using System.Collections.Generic;
using System.Text;
using Data.Read.Customers.Queries;
using FluentValidation;

namespace Data.Read.Customers.Validators
{
    public class GetCustomerListValidator : AbstractValidator<GetCustomerList>
    {
        public GetCustomerListValidator()
        {
            RuleFor(x => x.PageNo).GreaterThan(0);
            RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
        }
    }
}
