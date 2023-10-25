using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LicenceShop.Application.Auth.Commands.BeginLoginCommand;
using LicenceShop.Application.Auth.Commands.CompleteLoginCommand;
using LicenceShop.Application.Customer.Commands.CreateCustomerCommand;

namespace LicenceShop.Api.Controllers;

public class AuthController : ApiControllerBase
{
    [AllowAnonymous]
    [HttpPost("Register")]
    // [Authorize(Roles = RentalCarAuthorization.Customer)]
    public async Task<ActionResult> Register(CreateCustomerCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [AllowAnonymous]
    [HttpPost("BeginLogin")]
    public async Task<ActionResult> BeginLogin(BeginLoginCommand command) => Ok(await Mediator.Send(command));

    [AllowAnonymous]
    [HttpGet("{validationToken}/CompleteLogin")]
    public async Task<ActionResult> CompleteLogin([FromRoute] string validationToken) => Ok(await Mediator.Send(new CompleteLoginCommand(validationToken)));
}
