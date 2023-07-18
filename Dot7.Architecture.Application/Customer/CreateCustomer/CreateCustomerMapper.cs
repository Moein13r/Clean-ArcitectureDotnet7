using AutoMapper;

namespace Dot7.Architecture.Application.Customer.CreateCustomer;

public class CreateCustomerMapper:Profile
{
    public CreateCustomerMapper()
    {
        CreateMap<CreateCustomerRequest, Dot7.Architecture.Domain.Entities.Customer>();
    }
}