using AutoMapper;
using LicenceShop.Application.Common.Dto.LicenceType;
using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.LicenceType.Commands;

public record CreateLicenceTypeCommand(CreateLicenceTypeDto LicenceType) : IRequest<string>;

public class CreateLicenceTypeCommandHandler : IRequestHandler<CreateLicenceTypeCommand, string>
{

    private readonly IMapper _mapper;

    public CreateLicenceTypeCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateLicenceTypeCommand request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Domain.Entities.LicenceType>(request.LicenceType);
        await data.SaveAsync(cancellation: cancellationToken);
        return "LicenceType was successfully created";
    }
}