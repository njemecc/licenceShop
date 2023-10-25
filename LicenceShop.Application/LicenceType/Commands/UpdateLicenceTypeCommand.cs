using AutoMapper;
using LicenceShop.Application.Common.Dto.LicenceType;
using LicenceShop.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.LicenceType.Commands;

public record UpdateLicenceTypeCommand(UpdateLicenceTypeDto LicenceType) : IRequest<string>;

public class UpdateLicenceTypeCommandHandler : IRequestHandler<UpdateLicenceTypeCommand, string>
{
    private readonly IMapper _mapper;

    public UpdateLicenceTypeCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<string> Handle(UpdateLicenceTypeCommand request, CancellationToken cancellationToken)
    {
        var licenceType = await DB.Find<Domain.Entities.LicenceType>().OneAsync(request.LicenceType.LicenceTypeId, cancellation: cancellationToken);
        if (licenceType == null) throw new NotFoundException("LicenceType not found");
        _mapper.Map(request.LicenceType, licenceType);
        await licenceType.SaveAsync(cancellation: cancellationToken);
        return "LicenceType was successfully updated";

    }
}
