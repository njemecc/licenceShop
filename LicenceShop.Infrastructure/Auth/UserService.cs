using System.Security.Claims;
using AspNetCore.Identity.MongoDbCore.Models;
using LicenceShop.Application.Common.Dto.User;
using LicenceShop.Application.Common.Interfaces;
using LicenceShop.Domain.Entities;
using LicenceShop.Infrastructure.Exceptions;
using MongoDB.Entities;

namespace LicenceShop.Infrastructure.Auth;

public class UserService : IUserService
{
    private readonly ApplicationUserManager _userManager;
    
    public UserService(ApplicationUserManager userManager)
    {
        _userManager = userManager;
    }

    public async Task CreateUserAsync(CreateUserDto user, List<string> roles)
    {
        var alreadyExist = await _userManager.FindByEmailAsync(user.Email);
        
        if (alreadyExist != null)
            throw new AuthException("This user already exists");
       
        var newUser = new ApplicationUser
        {
            Email = user.Email,
            UserName = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Balance = 100000,
            Licences = new List<Licence>(),
            UserRoles = new List<string>()
        };
        
        

        try
        {
            
            newUser.Claims.Add(new MongoClaim { Type = ClaimTypes.Email, Value = user.Email });
            newUser.Claims.AddRange(roles.Select(userRole => new MongoClaim
            {
                Type = ClaimTypes.Role, Value = userRole
            }));
            

            var result = await _userManager.CreateAsync(newUser);

            if (!result.Succeeded)
            {
                throw new AuthException("Could not create a new user",
                    new { Errors = result.Errors.ToList() });
            }

            var rolesResult = await _userManager.AddToRolesAsync(newUser,
                roles.Select(nr => nr.ToUpper()));

            if (!rolesResult.Succeeded)
            {
                await _userManager.DeleteAsync(newUser);

                throw new AuthException("Could not add roles to user",
                    new { Errors = rolesResult.Errors.ToList() });
            }

            var newRoles = _userManager.GetRolesAsync(newUser).Result.ToList();
            newUser.UserRoles.AddRange(newRoles);
            await _userManager.UpdateAsync(newUser);
        }
        catch (Exception e)
        {
            await _userManager.DeleteAsync(newUser);
            
            throw new AuthException("Could not create a new user",
                e);
        }
    }

    public Task DeleteUserAsync(ApplicationUser user) => _userManager.DeleteAsync(user);
    public List<ApplicationUser> GetAllUsers() => _userManager.Users.ToList();
    public Task UpdateUserAsync(ApplicationUser user) => _userManager.UpdateAsync(user);
    public Task<ApplicationUser?> GetUserAsync(string id) => _userManager.FindByIdAsync(id);
    public Task<ApplicationUser?> GetUserByEmailAsync(string id) => _userManager.FindByEmailAsync(id);
    public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName) => _userManager.IsInRoleAsync(user,
        roleName);
}
