using LicenceShop.Application.Common.Dto.Car;
using LicenceShop.Application.Common.Interfaces;
using MediatR;
using MongoDB.Driver;
using MongoDB.Entities;
using LicenceShop.Domain.Entities;

namespace LicenceShop.Application.Car.Commands;

public record CreateCarCommand(CreateCarDto Car) : IRequest<string>;

public class CreateCarHandler : IRequestHandler<CreateCarCommand, string>
{

    private readonly IUserService _userService;

    public CreateCarHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<string> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var vendor = await DB.Find<Domain.Entities.Vendor>().OneAsync(request.Car.VendorId, cancellationToken);

        if (vendor == null)
        {
            throw new Exception("Vendor not found");
        }


        var users = new List<ApplicationUser>();
        foreach (var item in request.Car.UserIds)
        {
            var user = await _userService.GetUserAsync(item);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            users.Add(user);
        }
        
        
        var otherUsers = new List<ApplicationUser>();
        foreach (var item in request.Car.OtherUsersIds)
        {
            var user = await _userService.GetUserAsync(item);
            
            if (user == null)
            {
                throw new Exception("User not found");
            }

            otherUsers.Add(user);
        }
        
        var data = new Domain.Entities.Car
        {
            Name = request.Car.Name,
            Active = request.Car.Active,
            YearProduction = request.Car.YearProduction,
            Vendor = new One<Domain.Entities.Vendor>(vendor)
        };

        data.Users = new List<ApplicationUser>();
        data.OtherUsers = new List<ApplicationUser>();
        
        data.Users.AddRange(users);
        data.OtherUsers.AddRange(otherUsers);
        
        
        await data.SaveAsync(cancellation: cancellationToken);
        
        
        return "Car was created";
    }
}

