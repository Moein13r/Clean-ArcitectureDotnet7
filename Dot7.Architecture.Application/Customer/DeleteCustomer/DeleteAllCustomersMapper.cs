using AutoMapper;

namespace Dot7.Architecture.Application.Customer.DeleteCustomer;
public class DeleteAllCustomersMapper:Profile
{
    public DeleteAllCustomersMapper()
    {
        CreateMap<Dot7.Architecture.Domain.Entities.Customer,DeleteAllCustomersResponse>();
    }
}
