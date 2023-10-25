using FluentValidation;
using LicenceShop.Application.Common.Dto.Vendor;

namespace LicenceShop.Application.Common.Validators.Vendors;

public class UpdateVendorDtoValidator : AbstractValidator<UpdateVendorDto>
{
    public UpdateVendorDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(512)
            .MinimumLength(3);
    }
}