namespace LicenceShop.Application.Common.Dto.Licence;

public record LicencePageableDto(List<LicenceDetailsDto> Licences, PaginationDto Pagination)
{
    internal LicencePageableDto AddPagination(PaginationDto pagination)
    {
        return this with { Pagination = pagination };
    }
};