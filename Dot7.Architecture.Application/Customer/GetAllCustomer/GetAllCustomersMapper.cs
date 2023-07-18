using AutoMapper;

namespace Dot7.Architecture.Application.Customer.GetAllBeaches;
public class GetAllCustomersMapper:Profile
{
    public GetAllCustomersMapper()
    {
        CreateMap<Dot7.Architecture.Domain.Entities.Customer,GetAllCustomersResponse>();
    }
}
