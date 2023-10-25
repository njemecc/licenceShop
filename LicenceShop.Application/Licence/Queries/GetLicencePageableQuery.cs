using AutoMapper;
using LicenceShop.Application.Common.Dto;
using LicenceShop.Application.Common.Dto.Licence;
using LicenceShop.Application.Extensions.Licence;
using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Licence.Queries;

public record GetLicencePageableQuery(int PageNumber, int PageSize, string? Search) : IRequest<LicencePageableDto>;

public class GetLicencePageableQueryHandler : IRequestHandler<GetLicencePageableQuery, LicencePageableDto>
{

    private readonly IMapper _mapper;

    public GetLicencePageableQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<LicencePageableDto> Handle(GetLicencePageableQuery request, CancellationToken cancellationToken)
    {
        var licence = await DB.PagedSearch<Domain.Entities.Licence>()
            .Sort(b => b.Name, MongoDB.Entities.Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);
        return _mapper.Map<LicencePageableDto>(licence.Results).AddPagination(new PaginationDto(licence.TotalCount, licence.PageCount));
    }
}
