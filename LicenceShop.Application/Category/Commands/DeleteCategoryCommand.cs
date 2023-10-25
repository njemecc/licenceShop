using LicenceShop.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Category.Commands;

public record DeleteCategoryCommand(string CategoryId) : IRequest<string>;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, string>
{
    public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.Category>(x => x.ID != null && x.ID.Equals(request.CategoryId), cancellation: cancellationToken);
        return "Category was successfully deleted";
    }
}