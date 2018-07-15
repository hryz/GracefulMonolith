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
    public class MoveCustomerHandler : ICommandHandler<MoveCustomer, Unit>
    {
        private readonly IRepository<Customer, Guid> _repository;
        private readonly IMediator _mediator;

        public MoveCustomerHandler(IRepository<Customer, Guid> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(MoveCustomer request, CancellationToken cancellationToken)
        {
            var customer = await _repository.Get(request.CustomerId, cancellationToken);

            var address = new Address(
                request.CountryCode,
                request.ZipCode,
                request.City,
                request.Street,
                request.House,
                request.Apartment);

            customer.Move(address);

            await _repository.Update(customer, cancellationToken);
            await _mediator.Publish(new CustomerMoved(request.CustomerId), cancellationToken);

            return Unit.Value;
        }
    }
}
