using FluentValidation;
using LicenceShop.Application.Common.Dto.Category;

namespace LicenceShop.Application.Common.Validators.Category;

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(512)
            .MinimumLength(3);
    }
}