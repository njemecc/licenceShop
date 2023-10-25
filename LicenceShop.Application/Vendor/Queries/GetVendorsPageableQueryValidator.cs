using FluentValidation;

namespace LicenceShop.Application.Vendor.Queries;

public class GetVendorsPageableQueryValidator : AbstractValidator<GetVendorsPageableQuery>
{
    public GetVendorsPageableQueryValidator()
    {
        RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(x => x.Search).MinimumLength(3).When(y => y != null);
    }
}