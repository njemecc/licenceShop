using FluentValidation;
using LicenceShop.Application.Common.Validators.Cars;

namespace LicenceShop.Application.Car.Commands;

public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
{
    public UpdateCarCommandValidator()
    {
        RuleFor(x => x.Car).SetValidator(new UpdateCarDtoValidator());
    }
}