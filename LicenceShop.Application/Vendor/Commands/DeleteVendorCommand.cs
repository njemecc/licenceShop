using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Vendor.Commands;

public record DeleteVendorCommand(string VendorId) : IRequest<string>;


public class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, string>
{
    public async Task<string> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.Vendor>(x => x.ID != null && x.ID.Equals(request.VendorId), cancellation: cancellationToken);
        return "Vendor was successfully deleted";
    }
}
