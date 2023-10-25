using Amazon.Runtime.Internal;
using AutoMapper;
using LicenceShop.Application.Common.Dto.Category;
using MediatR;
using MongoDB.Entities;
using IRequest = MediatR.IRequest;

namespace LicenceShop.Application.Category.Commands;

public record CreateCategoryCommand(CreateCategoryDto Category) : IRequest<string>;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, string>
{

    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }


    public async Task<string> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Domain.Entities.Category>(request.Category);
        await data.SaveAsync(cancellation: cancellationToken);
        return "Category was successfully created";
    }
}

