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
    public class RegisterCustomerHandler : ICommandHandler<RegisterCustomer, Guid>
    {
        private readonly IRepository<Customer, Guid> _repository;
        private readonly IMediator _mediator;

        public RegisterCustomerHandler(IRepository<Customer, Guid> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(RegisterCustomer request, CancellationToken cancellationToken)
        {
            var address = new Address(
                request.CountryCode,
                request.ZipCode,
                request.City,
                request.Street,
                request.House,
                request.Apartment);

            var contact = new Contact(
                request.Title,
                request.FirstName,
                request.MiddleName,
                request.LastName);

            var customer = new Customer(contact, request.BirthDate, address);

            await _repository.Create(customer, cancellationToken);
            await _mediator.Publish(new CustomerRegistered(customer.Id), cancellationToken);

            return customer.Id;
        }
    }
}
