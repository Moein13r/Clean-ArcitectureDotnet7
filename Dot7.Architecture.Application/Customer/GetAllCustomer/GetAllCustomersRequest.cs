using MediatR;
using System.ComponentModel.Design;

namespace Dot7.Architecture.Application.Customer.GetAllBeaches;
public class GetAllCustomersRequest : IRequest<List<GetAllCustomersResponse>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public long BankAccountNumber { get; set; }

    public Func<GetAllCustomersResponse, bool> GetQueryFilterAction()
    {
        return (itm) => itm != null && itm.PhoneNumber == PhoneNumber;
    }
}
