using LicenceShop.Application.Common.Constants;
using LicenceShop.Application.Common.Dto.User;
using LicenceShop.Application.Common.Interfaces;
using MediatR;

namespace LicenceShop.Application.Customer.Commands.CreateCustomerCommand;

public record CreateCustomerCommand(CreateUserDto Customer) : IRequest;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly IUserService _userService;

    public CreateCustomerHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserAsync(request.Customer,
            new List<string> { RentalCarAuthorization.Customer });
    }
}
