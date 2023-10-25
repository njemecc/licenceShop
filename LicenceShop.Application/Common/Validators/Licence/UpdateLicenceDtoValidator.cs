using FluentValidation;
using LicenceShop.Application.Common.Dto.Licence;

namespace LicenceShop.Application.Common.Validators.Licence;

public class UpdateLicenceDtoValidator : AbstractValidator<UpdateLicenceDto>
{
    public UpdateLicenceDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(512)
            .MinimumLength(3);
        RuleFor(x => x.IsSold)
            .NotEmpty()
            .Must(x =>
            {
                if (x == true) return true;
                return x == false;
            });
        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThanOrEqualTo(1000);
    }
    
    private static bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
    }