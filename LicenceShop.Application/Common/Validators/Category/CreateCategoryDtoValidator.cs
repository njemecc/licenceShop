using FluentValidation;
using LicenceShop.Application.Common.Dto.Category;

namespace LicenceShop.Application.Common.Validators.Category;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(512)
            .MinimumLength(3)
            .NotEmpty();
        RuleFor(x => x.Active)
            .NotEmpty();
    }
}