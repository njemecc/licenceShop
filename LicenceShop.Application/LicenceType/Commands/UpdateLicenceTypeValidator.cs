using FluentValidation;
using LicenceShop.Application.Common.Validators.LicenceType;

namespace LicenceShop.Application.LicenceType.Commands;

public class UpdateLicenceTypeValidator : AbstractValidator<UpdateLicenceTypeCommand>
{
    public UpdateLicenceTypeValidator()
    {
        RuleFor(x => x.LicenceType).SetValidator(new UpdateLicenceTypeDtoValidator());

    }
}