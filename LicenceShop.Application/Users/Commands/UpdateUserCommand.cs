using AutoMapper;
using LicenceShop.Application.Common.Dto.User;
using LicenceShop.Application.Common.Exceptions;
using LicenceShop.Application.Common.Interfaces;
using MediatR;

namespace LicenceShop.Application.Users.Commands;

public record UpdateUserCommand(UpdateUserDto User) : IRequest<string>;


public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
{

    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }


    public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserAsync(request.User.UserId);
        if (user == null) throw new NotFoundException("User not found");
        _mapper.Map(request.User, user);
        await _userService.UpdateUserAsync(user);
        return "User was updated successfully";
    }
}