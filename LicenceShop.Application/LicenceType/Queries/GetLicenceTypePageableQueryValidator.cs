using FluentValidation;

namespace LicenceShop.Application.LicenceType.Queries;

public class GetLicenceTypePageableQueryValidator : AbstractValidator<GetLicenceTypePageableQuery>
{
    public GetLicenceTypePageableQueryValidator()
    {
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(x => x.Search).MinimumLength(3).When(y => y != null);
    }
}