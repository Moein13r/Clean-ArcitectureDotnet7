using Dot7.Architecture.Application.Customer.CreateCustomer;
using Dot7.Architecture.Application.Customer.DeleteCustomer;
using Dot7.Architecture.Application.Customer.GetAllBeaches;
using Dot7.Architecture.Application.Customer.UpdateCustomer;
using Dot7.Architecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dot7.Architecture.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAsync()
    {
        var response = await _mediator.Send(new GetAllCustomersRequest());
        return Ok(response);
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetCustomersByFilterAsync(GetAllCustomersRequest filterParams)
    {
        var response = await _mediator.Send(filterParams);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> PostAsync(CreateCustomerRequest customerRequest)
    {
        var newlyCreateItemId = await _mediator.Send(customerRequest);
        return Ok(newlyCreateItemId);
    }
    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteAsync(int Id)
    {
        bool deleted = await _mediator.Send(new DeleteAllCustomersRequest { Id = Id });
        return Ok(deleted);
    }
    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateAsync(UpdateCustomersRequest customerRequest)
    {
        var deleted = await _mediator.Send(customerRequest);
        return Ok(deleted);
    }
}