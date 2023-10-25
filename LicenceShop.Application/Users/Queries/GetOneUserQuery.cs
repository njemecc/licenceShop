using AutoMapper;
using LicenceShop.Application.Common.Dto.User;
using LicenceShop.Application.Common.Exceptions;
using LicenceShop.Application.Common.Interfaces;
using MediatR;

namespace LicenceShop.Application.Users.Queries;

public record GetOneUserQuery(string UserId) : IRequest<UserDetailsDto>;


public class GetOneUserQueryHandler : IRequestHandler<GetOneUserQuery, UserDetailsDto>
{

    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetOneUserQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<UserDetailsDto> Handle(GetOneUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserAsync(request.UserId);
        if (user == null) throw new NotFoundException("Customer not found");
        return await Task.FromResult(_mapper.Map<UserDetailsDto>(user));
    }
}