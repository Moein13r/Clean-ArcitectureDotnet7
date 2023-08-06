using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dot7.Architecture.Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dot7.Architecture.Application.Customer.GetAllBeaches;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersRequest, List<GetAllCustomersResponse>>
{
    private readonly ICustomerDbContext _myWorldDbContext;
    private readonly IMapper _mapper;
    public GetAllCustomersQueryHandler(ICustomerDbContext myWorldDbContext,
    IMapper mapper)
    {
        _myWorldDbContext = myWorldDbContext;
        _mapper = mapper;
    }
    public Task<List<GetAllCustomersResponse>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_myWorldDbContext.Customer.ProjectTo<GetAllCustomersResponse>(_mapper.ConfigurationProvider)
        .Where(request.GetQueryFilterAction()).ToList());
    }
}