using FluentValidation;
using LicenceShop.Application.Common.Dto.LicenceType;

namespace LicenceShop.Application.Common.Validators.LicenceType;

public class CreateLicenceTypeDtoValidator : AbstractValidator<CreateLicenceTypeDto>
{
    public CreateLicenceTypeDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(512)
            .MinimumLength(3)
            .NotEmpty();
        RuleFor(x => x.Active)
            .NotEmpty();
    }
}