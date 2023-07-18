
using FluentValidation;

namespace Dot7.Architecture.Application.Customer.CreateCustomer;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
    }

}