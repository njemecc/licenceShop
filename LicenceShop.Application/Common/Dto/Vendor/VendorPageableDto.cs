namespace LicenceShop.Application.Common.Dto.Vendor;

// public record VendorPageableDto<T1, T2, T3>(T1 Results, T2 TotalCount, T3 PageCount);
public record VendorPageableDto(List<VendorDetailsDto> Vendors, PaginationDto Pagination)
{
    internal VendorPageableDto AddPagination(PaginationDto pagination)
    {
        return this with { Pagination = pagination };
    }
}
