namespace LicenceShop.Application.Common.Dto.Car;

public record CarPageableDto(List<CarDetailsDto> Users, PaginationDto Pagination)
{
    internal CarPageableDto AddPagination(PaginationDto pagination)
    {
        return this with { Pagination = pagination };
    }
}