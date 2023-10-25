using FluentValidation;
using MongoDB.Entities;
using LicenceShop.Domain.Entities;

namespace LicenceShop.Application.Customer.Commands.CreateCustomerCommand;

public class CreateCustomerModelValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerModelValidator()
    {
        RuleFor(x => x.Customer.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");
    }
    
    
}
