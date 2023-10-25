using FluentValidation;
using LicenceShop.Application.Common.Dto.LicenceType;

namespace LicenceShop.Application.Common.Validators.LicenceType;

public class UpdateLicenceTypeDtoValidator : AbstractValidator<UpdateLicenceTypeDto>
{
    public UpdateLicenceTypeDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(512)
            .MinimumLength(3);
    }
}