using AutoMapper;

namespace Dot7.Architecture.Application.Customer.UpdateCustomer;
public class UpdateCustomersMapper:Profile
{
    public UpdateCustomersMapper()
    {
        CreateMap<Dot7.Architecture.Domain.Entities.Customer, UpdateCustomersResponse>();
    }
}
