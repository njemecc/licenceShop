using FluentValidation;
using LicenceShop.Application.Common.Validators.Vendors;

namespace LicenceShop.Application.Vendor.Commands;

public class UpdateVendorCommandValidator : AbstractValidator<UpdateVendorCommand>
{
    public UpdateVendorCommandValidator()
    {
        RuleFor(x => x.Vendor).SetValidator(new UpdateVendorDtoValidator());
    }
}