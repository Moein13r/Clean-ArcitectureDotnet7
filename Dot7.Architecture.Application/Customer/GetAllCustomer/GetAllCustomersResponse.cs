using System.ComponentModel.DataAnnotations;

namespace Dot7.Architecture.Application.Customer.GetAllBeaches;
public class GetAllCustomersResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public long BankAccountNumber { get; set; }
}
