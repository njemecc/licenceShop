using FluentValidation;
using LicenceShop.Application.Common.Validators.Licence;

namespace LicenceShop.Application.Licence.Commands;

public class CreateLicenceCommandValidator : AbstractValidator<CreateLicenceCommand>
{
    public CreateLicenceCommandValidator()
    {
        RuleFor(x => x.Licence).SetValidator(new CreateLicenceDtoValidator());
    }
}