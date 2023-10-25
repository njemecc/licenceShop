using System.Runtime.InteropServices.JavaScript;
using FluentValidation;
using LicenceShop.Application.Common.Dto.Car;

namespace LicenceShop.Application.Common.Validators.Cars;

public class CreateCarDtoValidator : AbstractValidator<CreateCarDto>
{
    public CreateCarDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(512)
            .NotEmpty()
            .MinimumLength(3);
        RuleFor(x => x.YearProduction)
            .NotEmpty()
            .GreaterThanOrEqualTo(1980)
            .LessThanOrEqualTo(2023);
        RuleFor(x => x.Active)
            .NotEmpty();
        RuleFor(x => x.VendorId)
            .NotEmpty();
    }
}