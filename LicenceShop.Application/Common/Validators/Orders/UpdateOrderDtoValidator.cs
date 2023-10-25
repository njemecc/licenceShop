using FluentValidation;
using LicenceShop.Application.Common.Dto.Order;

namespace LicenceShop.Application.Common.Validators.Orders;

public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
{
    public UpdateOrderDtoValidator()
    {
        RuleFor(x => x.TotalPrice).NotNull();
    }
}