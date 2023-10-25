using LicenceShop.Application.Common.Exceptions;
using LicenceShop.Application.Common.Interfaces;
using MediatR;

namespace LicenceShop.Application.Users.Commands;

public record DeleteUserCommand(string UserId) : IRequest<string>;


public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
{

    private readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserAsync(request.UserId);
        if (user == null) throw new NotFoundException("User not found");
        await _userService.DeleteUserAsync(user);
        return "User was successfully deleted";
    }
}
