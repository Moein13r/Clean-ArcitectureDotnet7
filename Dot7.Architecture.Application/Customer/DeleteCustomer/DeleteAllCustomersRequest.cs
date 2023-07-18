using MediatR;

namespace Dot7.Architecture.Application.Customer.DeleteCustomer;
public class DeleteAllCustomersRequest : IRequest<bool>
{
    public int Id { get; set; }
}
