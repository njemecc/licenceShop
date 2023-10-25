using AutoMapper;
using LicenceShop.Application.Common.Dto;
using LicenceShop.Application.Common.Dto.User;
using LicenceShop.Application.Common.Interfaces;
using LicenceShop.Domain.Entities;
using MediatR;
using MongoDB.Entities;

namespace LicenceShop.Application.Users.Queries;

public record GetAllUsersQuery() : IRequest<UserListDto>;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, UserListDto>
{

    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetAllUsersQueryHandler(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    public Task<UserListDto> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users =  _userService.GetAllUsers();
        return Task.FromResult(_mapper.Map<UserListDto>(users));
    }
}