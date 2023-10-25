namespace LicenceShop.Application.Common.Dto.User;

public record UserDetailsDto(string? FirstName, string? LastName, string? Email, string? UserName,
    string? NormalizedUserName, double Balance, IEnumerable<string?> Licences, List<string> Roles)
{
    internal UserDetailsDto AddLicences(IEnumerable<string?> licences)
    {
        return this with { Licences = licences };
    }
};
