using AutoMapper;
using LicenceShop.Application.Common.Dto;
using LicenceShop.Application.Common.Dto.User;
using LicenceShop.Domain.Entities;

namespace LicenceShop.Application.Mappers.Users;

public class MappingProfile : Profile
{
    
    public MappingProfile()
    {
        CreateMap<UpdateUserDto, ApplicationUser>().ReverseMap();
        CreateMap<Domain.Entities.ApplicationUser, UserDetailsDto>().ConstructUsing(x => GetUserDetails(x));
        CreateMap<IEnumerable<Domain.Entities.ApplicationUser>, UserListDto>().ConstructUsing(x => GetUserList(x));
    }
    
    
    private static UserDetailsDto GetUserDetails(Domain.Entities.ApplicationUser user)
    {
        return 
            new UserDetailsDto
            (
                user.FirstName,
                user.LastName,
                user.Email,
                user.UserName,
                user.NormalizedUserName,
                user.Balance,
                user.Licences.Select(x => x.Name),
                user.UserRoles
            );
    }



    private static UserListDto GetUserList(IEnumerable<Domain.Entities.ApplicationUser> users)
    {
        var userList = users.Select(GetUserDetails).ToList();
        return new UserListDto(userList);
    }
    
    
}