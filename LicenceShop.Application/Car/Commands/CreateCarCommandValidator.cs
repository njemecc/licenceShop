using FluentValidation;
using LicenceShop.Application.Common.Validators.Cars;

namespace LicenceShop.Application.Car.Commands;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(x => x.Car).SetValidator(new CreateCarDtoValidator());
    }
}