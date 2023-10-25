using FluentValidation;

namespace LicenceShop.Application.Car.Queries;

public class GetCarsPageableQueryValidator : AbstractValidator<GetCarsPageableQuery>
{
    public GetCarsPageableQueryValidator()
    {
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(x => x.Search).MinimumLength(3).When(y => y != null);
    }
}