using FluentValidation;
using LicenceShop.Application.Common.Dto.Licence;

namespace LicenceShop.Application.Common.Validators.Licence;

public class CreateLicenceDtoValidator : AbstractValidator<CreateLicenceDto>
{
    public CreateLicenceDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(512)
            .NotEmpty()
            .MinimumLength(3);
        RuleFor(x => x.StartDate)
            .NotEmpty()
            .Must(BeAValidDate);
        RuleFor(x => x.EndDate)
            .NotEmpty()
            .Must(BeAValidDate);
        RuleFor(x => x.VendorId)
            .NotEmpty();
        RuleFor(x => x.CategoryId)
            .NotEmpty();
        RuleFor(x => x.TypeId)
            .NotEmpty();
        RuleFor(x => x.OwnerId)
            .NotEmpty();
        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThanOrEqualTo(1000);
    }
    
    private static bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
    
    
}