using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Customers.Commands;
using Data.Read.Abstract;
using Data.Read.Customers.Queries;
using Data.Read.Customers.ReadModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator) => _mediator = mediator;

        //Queries

        [HttpGet("list")]
        public Task<IPageResult<CustomerListItem>> GetList([FromQuery] GetCustomerList query, CancellationToken token) => _mediator.Send(query, token);

        [HttpGet("{id}")]
        public Task<CustomerDetails> GetDetails([FromRoute] GetCustomerDetails query, CancellationToken token) => _mediator.Send(query, token);

        //Commands

        [HttpPost("register")]
        public async Task<Guid> Register([FromBody] RegisterCustomer cmd, CancellationToken token) => await _mediator.Send(cmd, token);

        [HttpPut("move")]
        public async Task Move([FromBody] MoveCustomer cmd, CancellationToken token) => await _mediator.Send(cmd, token);

        [HttpPut("enable")]
        public async Task Enable([FromBody] EnableCustomer cmd, CancellationToken token) => await _mediator.Send(cmd, token);

        [HttpPut("disable")]
        public async Task Disable([FromBody] DisableCustomer cmd, CancellationToken token) => await _mediator.Send(cmd, token);
    }
}
