using LicenceShop.Application.Common.Dto.Vendor;
using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Vendor.Queries;

public record GetOneVendorQuery(string VendorId) : IRequest<VendorDetailsDto>
{
    
}

public class GetOneVendorQueryHandler : IRequestHandler<GetOneVendorQuery, VendorDetailsDto>
{
    public async Task<VendorDetailsDto> Handle(GetOneVendorQuery request, CancellationToken cancellationToken)
    {
        var vendor = await DB.Find<Domain.Entities.Vendor>()
            .OneAsync(request.VendorId, cancellation: cancellationToken);

        if (vendor == null)
        {
            throw new Exception("Vendor not found");
        }
        return new VendorDetailsDto(vendor.Name, vendor.Active);
    }
}