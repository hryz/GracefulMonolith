using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstract;
using Application.Customers.CommandHandlers;
using Application.Customers.Commands;
using Application.Customers.Events;
using AutoFixture;
using Domain.Customer;
using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Tests.Unit.Application.Customers
{
    [TestClass]
    public class CustomerCommandTests
    {
        private readonly IRepository<Customer, Guid> _repository;
        private readonly IMediator _mediator;
        private readonly IFixture _fixture;
        private readonly CancellationToken _none;

        private readonly Customer _customer;

        public CustomerCommandTests()
        {
            _repository = Substitute.For<IRepository<Customer, Guid>>();
            _mediator = Substitute.For<IMediator>();
            _fixture = new Fixture();
            _none = CancellationToken.None;

            _customer = _fixture.Create<Customer>();
            _repository
                .Get(Guid.Empty, _none)
                .ReturnsForAnyArgs(Task.FromResult(_customer));
        }

        [TestMethod]
        public async Task Should_Handle_Enable_Customer_Command()
        {
            //arrange
            _customer.Disable();
            var sut = new EnableCustomerHandler(_repository, _mediator);

            //act
            await sut.Handle(new EnableCustomer(_customer.Id), _none);

            //assert
            _customer.Enabled.Should().BeTrue();
            await _repository.Received().Update(_customer, _none);
            await _mediator.ReceivedWithAnyArgs().Publish<CustomerEnabled>(null, _none);
        }

        [TestMethod]
        public async Task Should_Handle_Disable_Customer_Command()
        {
            //arrange
            _customer.Enable();
            var sut = new DisableCustomerHandler(_repository, _mediator);

            //act
            await sut.Handle(new DisableCustomer(_customer.Id), _none);

            //assert
            _customer.Enabled.Should().BeFalse();
            await _repository.Received().Update(_customer, _none);
            await _mediator.ReceivedWithAnyArgs().Publish<CustomerDisabled>(null, _none);
        }

        [TestMethod]
        public async Task Should_Handle_Move_Customer_Command()
        {
            //arrange
            var cmd = _fixture.Create<MoveCustomer>();
            var sut = new MoveCustomerHandler(_repository, _mediator);

            //act
            await sut.Handle(cmd, _none);

            //assert
            _customer.Address.Should().BeEquivalentTo(cmd, x => x.Excluding(e => e.CustomerId));
            await _repository.Received().Update(_customer, _none);
            await _mediator.ReceivedWithAnyArgs().Publish<CustomerMoved>(null, _none);
        }

        [TestMethod]
        public async Task Should_Handle_Register_Customer_Command()
        {
            //arrange
            var cmd = _fixture.Create<RegisterCustomer>();
            var sut = new RegisterCustomerHandler(_repository, _mediator);

            Customer newCustomer = null;
            _repository
                .When(x => x.Create(Arg.Any<Customer>(), _none))
                .Do(x => newCustomer = x.Arg<Customer>());

            //act
            await sut.Handle(cmd, _none);

            //assert
            newCustomer.Should().NotBeNull();
            newCustomer.Address.Should().BeEquivalentTo(new
            {
                cmd.CountryCode,
                cmd.ZipCode,
                cmd.City,
                cmd.Street,
                cmd.House,
                cmd.Apartment
            });

            newCustomer.Contact.Should().BeEquivalentTo(new
            {
                cmd.Title,
                cmd.FirstName,
                cmd.MiddleName,
                cmd.LastName,
            });

            await _repository.Received().Create(newCustomer, _none);
            await _mediator.ReceivedWithAnyArgs().Publish<CustomerRegistered>(null, _none);
        }

    }
}
