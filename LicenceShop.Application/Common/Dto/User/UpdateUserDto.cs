namespace LicenceShop.Application.Common.Dto.User;

public record UpdateUserDto(string UserId, string? FirstName, string? LastName, string? Email)
{
    internal UpdateUserDto AddLoggedInUser(string userId)
    {
        return this with { UserId = userId };
    }
}