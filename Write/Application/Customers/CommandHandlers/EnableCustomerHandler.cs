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
    public class EnableCustomerHandler : ICommandHandler<EnableCustomer, Unit>
    {
        private readonly IRepository<Customer, Guid> _repository;
        private readonly IMediator _mediator;

        public EnableCustomerHandler(IRepository<Customer, Guid> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(EnableCustomer request, CancellationToken cancellationToken)
        {
            var customer = await _repository.Get(request.CustomerId, cancellationToken);
            
            customer.Disable();

            await _repository.Update(customer, cancellationToken);
            await _mediator.Publish(new CustomerEnabled(request.CustomerId), cancellationToken);

            return Unit.Value;
        }
    }
}
