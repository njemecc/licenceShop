using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Car.Commands;

public record DeleteCarCommand(string CarId) : IRequest<string>;


public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, string>
{
    public async Task<string> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.Car>(x => x.ID != null && x.ID.Equals(request.CarId), cancellation: cancellationToken);
        return "Car was successfully deleted";
    }
};