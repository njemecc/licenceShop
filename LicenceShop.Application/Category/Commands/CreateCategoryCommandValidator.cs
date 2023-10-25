using FluentValidation;
using LicenceShop.Application.Common.Validators.Category;

namespace LicenceShop.Application.Category.Commands;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Category).SetValidator(new CreateCategoryDtoValidator());
    }
}