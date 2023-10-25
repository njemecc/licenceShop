using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Order.Commands;

public record DeleteOrderCommand(string OrderId) : IRequest<string>;


public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, string>
{
    public async Task<string> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.Order>(x => x.ID != null && x.ID.Equals(request.OrderId), cancellation: cancellationToken);
        return "Order was successfully deleted";
    }
}