using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Licence.Commands;

public record DeleteLicenceCommand(string LicenceId) : IRequest<string>;


public class DeleteLicenceCommandHandler : IRequestHandler<DeleteLicenceCommand, string>
{
    public async Task<string> Handle(DeleteLicenceCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.Licence>(x => x.ID != null && x.ID.Equals(request.LicenceId), cancellation: cancellationToken);
        return "Licence was successfully deleted";
    }
}
