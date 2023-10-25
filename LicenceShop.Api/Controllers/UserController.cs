using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LicenceShop.Application.Administrator.Commands.CreateAdministratorCommand;
using LicenceShop.Application.Common.Constants;
using LicenceShop.Application.Common.Dto.User;
using LicenceShop.Application.Customer.Commands.CreateCustomerCommand;
using LicenceShop.Application.Marketer.Commands;
using LicenceShop.Application.Users.Commands;
using LicenceShop.Application.Users.Queries;
using LicenceShop.Domain.Entities;

namespace LicenceShop.Api.Controllers;

// [Authorize(Roles = $"{RentalCarAuthorization.Customer}, {RentalCarAuthorization.Administrator}")]
public class UserController : ApiControllerBase
{


    [HttpGet("CetOneUser")]
    public async Task<ActionResult<UserDetailsDto>> GetOneUser([FromQuery] GetOneUserQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpGet("CetAllUsers")]
    public async Task<ActionResult<List<ApplicationUser>>> GetAllUsers([FromQuery] GetAllUsersQuery query) =>
        Ok(await Mediator.Send(query));


    [HttpPut("UpdateUser")]
    public async Task<ActionResult<string>> UpdateUser(UpdateUserCommand command) 
        => Ok(await Mediator.Send(command));


    [HttpDelete("DeleteUser")]
    public async Task<ActionResult<string>> DeleteUser(DeleteUserCommand command)
        => Ok(await Mediator.Send(command));
    
    
    [HttpPost("CreateMarketer")]
    // [Authorize(Roles = RentalCarAuthorization.Customer)]
    public async Task<ActionResult<string>> CreateMarketer(CreateMarketerCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    
    
    
    [HttpPost("CreateAdministrator")]
    // [Authorize(Roles = RentalCarAuthorization.Administrator)]
    public async Task<ActionResult> CreateAdministrator(CreateAdministratorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}
