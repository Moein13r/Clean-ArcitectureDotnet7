using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dot7.Architecture.Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dot7.Architecture.Application.Customer.DeleteCustomer;

public class DeleteAllCustomersQueryHandler : IRequestHandler<DeleteAllCustomersRequest, bool>
{
    private readonly ICustomerDbContext _myWorldDbContext;
    private readonly IMapper _mapper;
    public DeleteAllCustomersQueryHandler(ICustomerDbContext myWorldDbContext,
    IMapper mapper)
    {
        _myWorldDbContext = myWorldDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteAllCustomersRequest request, CancellationToken cancellationToken)
    {
        if (_myWorldDbContext.Customer.Any(ent => ent.Id == request.Id))
            _myWorldDbContext.Customer.Remove(_myWorldDbContext.Customer.Where(ent => ent.Id == request.Id).FirstOrDefault());
        return await _myWorldDbContext.SaveToDbAsync() > 0;
    }
}