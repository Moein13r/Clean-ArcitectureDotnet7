using AutoMapper;
using BlazorWeb.Data;
using Dot7.Architecture.Application.Customer.CreateCustomer;
using MediatR;

namespace BlazorWeb.Service
{
    public class CustomerService : ICustomerService
    {
        readonly IMediator _mediator;
        readonly IMapper _mapper;

        public CustomerService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<int> AddCustomer(Customer customer, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new CreateCustomerRequest
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                BankAccountNumber = customer.BankAccountNumber,
                Email= customer.Email,
                DateOfBirth= customer.DateOfBirth
            },
                cancellationToken);
        }
    }
}
