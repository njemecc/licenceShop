using AutoMapper;
using LicenceShop.Application.Common.Dto;
using LicenceShop.Application.Common.Dto.Vendor;
using MediatR;
using MongoDB.Entities;
using LicenceShop.Application.Extensions.Vendor;

namespace LicenceShop.Application.Vendor.Queries;

public record GetVendorsPageableQuery( int PageNumber, int PageSize, string? Search) : IRequest<VendorPageableDto>;


public class GetAllVendorsPageableQueryHandler : IRequestHandler<GetVendorsPageableQuery, VendorPageableDto>
{
    private readonly IMapper _mapper;

    public GetAllVendorsPageableQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }


    public async Task<VendorPageableDto> Handle(GetVendorsPageableQuery request, CancellationToken cancellationToken)
    {
        var vendors = await DB.PagedSearch<Domain.Entities.Vendor>()
            .Sort(b => b.Name, MongoDB.Entities.Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);
        return _mapper.Map<VendorPageableDto>(vendors.Results).AddPagination(new PaginationDto(vendors.TotalCount, vendors.PageCount));
    }
}