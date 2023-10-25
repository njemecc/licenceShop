using FluentValidation;
using LicenceShop.Application.Common.Dto.Car;

namespace LicenceShop.Application.Common.Validators.Cars;

public class UpdateCarDtoValidator : AbstractValidator<UpdateCarDto>
{
    public UpdateCarDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(512)
            .MinimumLength(3);
        RuleFor(x => x.YearProduction)
            .GreaterThanOrEqualTo(1980)
            .LessThanOrEqualTo(2023);
    }
}