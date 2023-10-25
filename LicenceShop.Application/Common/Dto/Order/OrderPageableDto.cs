namespace LicenceShop.Application.Common.Dto.Order;

public record OrderPageableDto(List<OrderDetailsDto> Orders, PaginationDto Pagination)
{
    internal OrderPageableDto AddPagination(PaginationDto pagination)
    {
        return this with { Pagination = pagination };
    }
};