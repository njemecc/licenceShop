namespace LicenceShop.Application.Common.Dto.Category;

public record CategoryPageableDto(List<CategoryDetailsDto> Categories, PaginationDto Pagination)
{
    internal CategoryPageableDto AddPagination(PaginationDto pagination)
    {
        return this with { Pagination = pagination };
    }
}