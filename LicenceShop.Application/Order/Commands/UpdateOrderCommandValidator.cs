using FluentValidation;
using LicenceShop.Application.Common.Validators.Orders;

namespace LicenceShop.Application.Order.Commands;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Order).SetValidator(new UpdateOrderDtoValidator());
    }
}