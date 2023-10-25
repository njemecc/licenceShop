using FluentValidation;

namespace LicenceShop.Application.Category.Queries;

public class GetPageableCategoryQueryValidator : AbstractValidator<GetPageableCategoryQuery>
{
    public GetPageableCategoryQueryValidator()
    {
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(x => x.Search).MinimumLength(3).When(y => y != null);
    }
}