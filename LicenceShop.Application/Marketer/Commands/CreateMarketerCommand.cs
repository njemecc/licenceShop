using LicenceShop.Application.Common.Constants;
using LicenceShop.Application.Common.Dto.User;
using LicenceShop.Application.Common.Interfaces;
using MediatR;

namespace LicenceShop.Application.Marketer.Commands;

public record CreateMarketerCommand(CreateUserDto Marketer) : IRequest<string>;

public class CreateMarketerCommandHandler : IRequestHandler<CreateMarketerCommand, string>
{
    
    private readonly IUserService _userService;

    public CreateMarketerCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<string> Handle(CreateMarketerCommand request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserAsync(request.Marketer,
            new List<string> { RentalCarAuthorization.Marketer});
        return "Registration successfully completed";
    }
}
