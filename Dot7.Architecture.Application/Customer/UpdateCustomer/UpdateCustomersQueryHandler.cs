using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dot7.Architecture.Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Timers;

namespace Dot7.Architecture.Application.Customer.UpdateCustomer;

public class UpdateCustomersQueryHandler : IRequestHandler<UpdateCustomersRequest, UpdateCustomersResponse>
{
    private readonly ICustomerDbContext _myWorldDbContext;
    private readonly IMapper _mapper;
    public UpdateCustomersQueryHandler(ICustomerDbContext myWorldDbContext,
    IMapper mapper)
    {
        _myWorldDbContext = myWorldDbContext;
        _mapper = mapper;
    }
    public async Task<UpdateCustomersResponse> Handle(UpdateCustomersRequest request, CancellationToken cancellationToken)
    {
        if (_myWorldDbContext.Customer.Any(c => c.Id == request.Id))
        {
            var customer = _myWorldDbContext.Customer
            .Update(_myWorldDbContext.Customer.Where(c => c.Id == request.Id).FirstOrDefault());
            return _mapper.Map<UpdateCustomersResponse>(customer?.Entity);
        }
        else
            throw new KeyNotFoundException("Id");
    }
}