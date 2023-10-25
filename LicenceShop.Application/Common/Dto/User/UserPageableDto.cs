namespace LicenceShop.Application.Common.Dto.User;

public record UserPageableDto(List<UserDetailsDto> Users, PaginationDto Pagination)
{
    internal UserPageableDto AddPagination(PaginationDto pagination)
    {
        return this with { Pagination = pagination };
    }
}
