using FluentValidation;
using LicenceShop.Application.Common.Validators.Vendors;

namespace LicenceShop.Application.Vendor.Commands;

public class CreateVendorCommandValidator : AbstractValidator<CreateVendorCommand>
{
    public CreateVendorCommandValidator()
    {
        RuleFor(x => x.Vendor).SetValidator(new CreateVendorDtoValidator());
    }
}