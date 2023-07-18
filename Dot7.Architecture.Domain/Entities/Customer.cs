using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dot7.Architecture.Domain.Entities;
[Table("Customer")]
public class Customer
{
    [Required]
    public int Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }
    [MaxLength(10)]
    public string DateOfBirth { get; set; }
    [MaxLength(11)]
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public long BankAccountNumber { get; set; }
}
