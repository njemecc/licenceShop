using LicenceShop.Application.Category.Commands;
using LicenceShop.Application.Category.Queries;
using LicenceShop.Application.Common.Constants;
using LicenceShop.Application.Common.Dto.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LicenceShop.Api.Controllers;

[Route("[controller]")]
public class CategoryController : ApiControllerBase
{

    [HttpGet("GetOneCategory")]
    public async Task<ActionResult<CategoryDetailsDto>> GetOneCategory([FromQuery] GetOneCategoryQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpGet("GetPageableCategory")]
    [Authorize(Roles = RentalCarAuthorization.Customer)]
    public async Task<ActionResult<CategoryPageableDto>> GetPageableCategory([FromQuery] GetPageableCategoryQuery query) =>
        Ok(await Mediator.Send(query));

    [HttpPost("CreateCategory")]
    public async Task<ActionResult<string>> CreateCategory(CreateCategoryCommand command) =>
        Ok(await Mediator.Send(command));
    
    [HttpPut("UpdateCategory")]
    public async Task<ActionResult<string>> UpdateCategory(UpdateCategoryCommand command) =>
        Ok(await Mediator.Send(command));
    
    [HttpDelete("CreateCategory")]
    public async Task<ActionResult<string>> DeleteCategory(DeleteCategoryCommand command) =>
        Ok(await Mediator.Send(command));
    
}