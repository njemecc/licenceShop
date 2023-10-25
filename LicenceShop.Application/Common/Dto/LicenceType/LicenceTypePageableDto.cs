namespace LicenceShop.Application.Common.Dto.LicenceType;

public record LicenceTypePageableDto(List<LicenceTypeDetailsDto> Types, PaginationDto Pagination)
{
    internal LicenceTypePageableDto AddPagination (PaginationDto pagination)
    {
        return this with { Pagination = pagination };
    }
};