using AutoMapper;
using Dot7.Architecture.Application.Context;
using MediatR;

namespace Dot7.Architecture.Application.Customer.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerRequest, int>
{
    private readonly ICustomerDbContext _myWorldDbContext;
    private readonly IMapper _mapper;
    public CreateCustomerCommandHandler(ICustomerDbContext myWorldDbContext,
    IMapper mapper)
    {
        _myWorldDbContext = myWorldDbContext;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var newBeach = _mapper.Map<Dot7.Architecture.Domain.Entities.Customer>(request);
        _myWorldDbContext.Customer.Add(newBeach);
        await _myWorldDbContext.SaveToDbAsync();
        return newBeach.Id;
    }
}