using FluentValidation;
using LicenceShop.Application.Common.Validators.Licence;

namespace LicenceShop.Application.Licence.Commands;

public class UpdateLicenceCommandValidator : AbstractValidator<UpdateLicenceCommand>
{
    public UpdateLicenceCommandValidator()
    {
        RuleFor(x => x.Licence).SetValidator(new UpdateLicenceDtoValidator());
    }
}