using FluentValidation;

namespace LicenceShop.Application.Administrator.Commands.CreateAdministratorCommand;

public class CreateAdministratorModelValidator : AbstractValidator<CreateAdministratorCommand>
{
    public CreateAdministratorModelValidator()
    {
        RuleFor(x => x.Admin.Email)
            .EmailAddress()
            .NotEmpty();
    }
}
