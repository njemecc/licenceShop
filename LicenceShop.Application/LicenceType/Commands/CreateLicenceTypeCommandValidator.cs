using FluentValidation;
using LicenceShop.Application.Common.Validators.LicenceType;

namespace LicenceShop.Application.LicenceType.Commands;

public class CreateLicenceTypeCommandValidator : AbstractValidator<CreateLicenceTypeCommand>
{
    public CreateLicenceTypeCommandValidator()
    {
        RuleFor(x => x.LicenceType).SetValidator(new CreateLicenceTypeDtoValidator());

    }
}