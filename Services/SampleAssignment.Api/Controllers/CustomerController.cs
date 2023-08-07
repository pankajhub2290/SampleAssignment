using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleAssignment.Application.Commands.CreateCustomer;
using SampleAssignment.Application.Commands.DeleteCustomer;
using SampleAssignment.Application.Commands.UpdateCustomer;
using SampleAssignment.Application.Queries.GetAllCustomers;
using SampleAssignment.Application.Queries.GetCustomerById;
using SampleAssignment.Shared.Models;

namespace SampleAssignment.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CustomerController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllCustomerQuery(), cancellationToken);
            return Ok(response);
        }
        [HttpGet("{customerId:int}")]
        public async Task<IActionResult> Get(int customerId, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetCustomerByIdQuery { Id = customerId }, cancellationToken);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CustomerRequestModel customerRequestModel , CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateCustomerCommand>(customerRequestModel);
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }
        [HttpPut("{customerId:int}")]
        public async Task<IActionResult> Put(int customerId, CustomerRequestModel customerRequestModel, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateCustomerCommand>(customerRequestModel);
            command.Id = customerId;
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }
        [HttpDelete("{customerId:int}")]
        public async Task<IActionResult> Delete(int customerId, CancellationToken cancellationToken)
        {
            var command = new DeleteCustomerCommand { Id = customerId };
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }
    }
}
