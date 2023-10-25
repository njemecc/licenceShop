using FluentValidation;
using LicenceShop.Application.Common.Dto.Vendor;

namespace LicenceShop.Application.Common.Validators.Vendors;

public class CreateVendorDtoValidator : AbstractValidator<CreateVendorDto>

{
    public CreateVendorDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(512)
            .MinimumLength(3)
            .NotEmpty();
        RuleFor(x => x.Active)
            .NotEmpty();
    }
}