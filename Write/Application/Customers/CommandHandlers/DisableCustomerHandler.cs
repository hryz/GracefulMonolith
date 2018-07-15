using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstract;
using Application.Customers.Commands;
using Application.Customers.Events;
using Domain.Customer;
using MediatR;

namespace Application.Customers.CommandHandlers
{
    public class DisableCustomerHandler : ICommandHandler<DisableCustomer, Unit>
    {
        private readonly IRepository<Customer, Guid> _repository;
        private readonly IMediator _mediator;

        public DisableCustomerHandler(IRepository<Customer, Guid> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DisableCustomer request, CancellationToken cancellationToken)
        {
            var customer = await _repository.Get(request.CustomerId, cancellationToken);
            
            customer.Disable();

            await _repository.Update(customer, cancellationToken);
            await _mediator.Publish(new CustomerDisabled(request.CustomerId), cancellationToken);

            return Unit.Value;
        }
    }
}
