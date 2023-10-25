using AutoMapper;
using LicenceShop.Application.Common.Dto;
using LicenceShop.Application.Common.Dto.LicenceType;
using LicenceShop.Application.Extensions.LicenceType;
using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.LicenceType.Queries;

public record GetLicenceTypePageableQuery(int PageNumber, int PageSize, string? Search) : IRequest<LicenceTypePageableDto>;

public class GetLicenceTypePageableQueryHandler : IRequestHandler<GetLicenceTypePageableQuery, LicenceTypePageableDto>
{

    private readonly IMapper _mapper;


    public GetLicenceTypePageableQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<LicenceTypePageableDto> Handle(GetLicenceTypePageableQuery request, CancellationToken cancellationToken)
    {
        var licenceTypes = await DB.PagedSearch<Domain.Entities.LicenceType>()
            .Sort(b => b.Name, MongoDB.Entities.Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);
        return _mapper.Map<LicenceTypePageableDto>(licenceTypes.Results).AddPagination(new PaginationDto(licenceTypes.TotalCount, licenceTypes.PageCount));
    }
}