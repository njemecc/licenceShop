using FluentValidation;
using LicenceShop.Application.Common.Dto.Order;

namespace LicenceShop.Application.Common.Validators.Orders;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .MinimumLength(3);
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .MinimumLength(3);
    }
}