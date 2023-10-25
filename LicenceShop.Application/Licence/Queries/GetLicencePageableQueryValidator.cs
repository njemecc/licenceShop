using FluentValidation;

namespace LicenceShop.Application.Licence.Queries;

public class GetLicencePageableQueryValidator : AbstractValidator<GetLicencePageableQuery>
{
    public GetLicencePageableQueryValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(x => x.Search).MinimumLength(3).When(y => y != null);
    }
}