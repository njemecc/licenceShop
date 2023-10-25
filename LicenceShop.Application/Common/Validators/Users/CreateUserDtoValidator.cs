using FluentValidation;
using LicenceShop.Application.Common.Dto.User;

namespace LicenceShop.Application.Common.Validators.Users;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .MaximumLength(512)
            .NotEmpty()
            .MinimumLength(3);
        RuleFor(x => x.LastName)
            .MaximumLength(512)
            .NotEmpty()
            .MinimumLength(3);
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
}
