using LicenceShop.Application.Common.Dto.User;
using LicenceShop.Domain.Entities;

namespace LicenceShop.Application.Common.Interfaces;

public interface IUserService
{
    public List<ApplicationUser> GetAllUsers();
    Task DeleteUserAsync(ApplicationUser user);
    Task UpdateUserAsync(ApplicationUser user);
    Task CreateUserAsync(CreateUserDto user, List<string> roles);
    Task<ApplicationUser?> GetUserAsync(string id);
    Task<ApplicationUser?> GetUserByEmailAsync(string id);
    Task<bool> IsInRoleAsync(ApplicationUser user, string roleName);
}
