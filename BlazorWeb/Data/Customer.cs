using AutoMapper;
using Dot7.Architecture.Application.Customer.CreateCustomer;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorWeb.Data;

public class Customer
{
    [DisplayName("FirstName")]
    [Required]
    public string FirstName { get; set; }
    [DisplayName("LastName")]
    [Required]
    public string LastName { get; set; }
    [DisplayName("DateOfBirth")]
    [Required]
    [StringLength(10, ErrorMessage = "DateOfBirth must be 10 charater example: 1379/04/22")]
    public string DateOfBirth { get; set; }
    [DisplayName("PhoneNumber")]
    [Required]
    [StringLength(11, ErrorMessage = "phone number must be 11 charater ")]
    public string PhoneNumber { get; set; }
    [DisplayName("Email")]
    [Required]
    public string Email { get; set; }
    [DisplayName("BankAccountNumber")]
    [Required]
    public long BankAccountNumber { get; set; }

}
public class CustomerMapper : Profile
{
    public CustomerMapper()
    {
        CreateMap<Customer, CreateCustomerRequest>();
    }
}