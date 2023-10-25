using FluentValidation;
using LicenceShop.Application.Common.Validators.Category;

namespace LicenceShop.Application.Category.Commands;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Category).SetValidator(new UpdateCategoryDtoValidator());
    }
}