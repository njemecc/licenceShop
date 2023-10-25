using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.LicenceType.Commands;

public record DeleteLicenceTypeCommand(string LicenceTypeId) : IRequest<string>;


public class DeleteLicenceTypeCommandHandler : IRequestHandler<DeleteLicenceTypeCommand, string>
{
    public async Task<string> Handle(DeleteLicenceTypeCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.LicenceType>(x => x.ID != null && x.ID.Equals(request.LicenceTypeId),
            cancellation: cancellationToken);

        return "LicenceType was successfully deleted";
    }
}