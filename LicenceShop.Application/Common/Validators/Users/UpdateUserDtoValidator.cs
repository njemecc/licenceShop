using FluentValidation;
using LicenceShop.Application.Common.Dto.User;

namespace LicenceShop.Application.Common.Validators.Users;

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .MaximumLength(512)
            .MinimumLength(3);
        RuleFor(x => x.LastName)
            .MaximumLength(512)
            .MinimumLength(3);
        RuleFor(x => x.Email)
            .EmailAddress();
    }
}