using LicenceShop.Application.Common.Dto.Licence;
using LicenceShop.Application.Licence.Commands;
using LicenceShop.Application.Licence.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LicenceShop.Api.Controllers;

[Route("[controller]")]
public class LicenceController : ApiControllerBase
{

    [HttpGet("GetOneLicence")]
    public async Task<ActionResult<LicenceDetailsDto>> GetOneLicence([FromQuery] GetOneLicenceQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpGet("GetLicencePageable")]
    public async Task<ActionResult<LicencePageableDto>> GetLicencePageable([FromQuery] GetLicencePageableQuery query) =>
        Ok(await Mediator.Send(query));
    
    
    [HttpPost("CreateLicence")]
    public async Task<ActionResult<string>> CreateLicence(CreateLicenceCommand command) =>
        Ok(await Mediator.Send(command));
    
    [HttpPut("UpdateLicence")]
    public async Task<ActionResult<string>> UpdateLicence(UpdateLicenceCommand command) =>
        Ok(await Mediator.Send(command));
    
    [HttpDelete("DeleteLicence")]
    public async Task<ActionResult<string>> DeleteLicence(DeleteLicenceCommand command) =>
        Ok(await Mediator.Send(command));

}