using FluentValidation;
using LicenceShop.Application.Common.Validators.Orders;

namespace LicenceShop.Application.Order.Commands;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Order).SetValidator(new CreateOrderDtoValidator());
    }
}