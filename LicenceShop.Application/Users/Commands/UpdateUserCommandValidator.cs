using FluentValidation;
using LicenceShop.Application.Common.Validators.Users;

namespace LicenceShop.Application.Users.Commands;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.User).SetValidator(new UpdateUserDtoValidator());
    }
}