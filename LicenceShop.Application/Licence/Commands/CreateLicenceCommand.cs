using LicenceShop.Application.Common.Dto.Licence;
using LicenceShop.Application.Common.Interfaces;
using LicenceShop.Domain.Entities;
using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Licence.Commands;

public record CreateLicenceCommand(CreateLicenceDto Licence) : IRequest<string>;


public record CreateLicenceCommandHandler : IRequestHandler<CreateLicenceCommand, string>
{

    private readonly IUserService _userService;

    public CreateLicenceCommandHandler(IUserService userService)
    {
        _userService = userService;
    }


    public async Task<string> Handle(CreateLicenceCommand request, CancellationToken cancellationToken)
    {
        var vendor = await DB.Find<Domain.Entities.Vendor>().OneAsync(request.Licence.VendorId, cancellationToken);

        if (vendor == null)
        {
            throw new Exception("Vendor not found");
        }
        
        
        var category = await DB.Find<Domain.Entities.Category>().OneAsync(request.Licence.CategoryId, cancellationToken);

        if (category == null)
        {
            throw new Exception("Category not found");
        }
        
        var type = await DB.Find<Domain.Entities.LicenceType>().OneAsync(request.Licence.TypeId, cancellationToken);

        if (type == null)
        {
            throw new Exception("LicenceType not found");
        }
        
        var user = await _userService.GetUserAsync(request.Licence.OwnerId);
        
        var data = new Domain.Entities.Licence()
        {
            Name = request.Licence.Name,
            StartDate = request.Licence.StartDate,
            EndDate = request.Licence.EndDate,
            Vendor = new One<Domain.Entities.Vendor>(vendor),
            Type = new One<Domain.Entities.LicenceType>(type),
            Category = new One<Domain.Entities.Category>(category),
            IsSold = request.Licence.IsSold,
            Price = request.Licence.Price,
            Active = true,
            Img = request.Licence.Img,
            Description = request.Licence.Description
        };
        
        if (user != null) data.Owner = user;
        
        
        await data.SaveAsync(cancellation: cancellationToken);

        return "Licence was successfully created";

    }
}
