using FluentValidation;

namespace LicenceShop.Application.Order.Queries;

public class GetOrdersPageableQueryValidator : AbstractValidator<GetOrderPageableQuery>
{
    public GetOrdersPageableQueryValidator()
    {
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(x => x.Search).MinimumLength(3).When(y => y != null);
    }
}