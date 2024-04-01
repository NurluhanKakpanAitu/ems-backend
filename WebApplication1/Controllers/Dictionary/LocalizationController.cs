using Application.Dto.Dictionary.Localization;
using Application.Services.Dictionary.Command;
using Application.Services.Dictionary.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.Dictionary;

[ApiController]
[Route("api/[controller]")]
public class LocalizationController(
    ILocalizationCommandService localizationCommandService, 
    ILocalizationQueryService localizationQueryService) : Controller
{
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] LocalizationCreateDto localizationCreateDto, CancellationToken cancellationToken)
    {
        try
        {
            await localizationCommandService.Create(localizationCreateDto, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut]
    [Route("update/{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] LocalizationUpdateDto localizationUpdateDto, CancellationToken cancellationToken)
    {
        try
        {
            await localizationCommandService.Update(id, localizationUpdateDto, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete]
    [Route("delete/{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        try
        {
            await localizationCommandService.Delete(id, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("get/{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var result = await localizationQueryService.GetByIdAsync(id, cancellationToken);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("get-all")]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] LocalizationQuery localizationQuery, CancellationToken cancellationToken)
    {
        try
        {
            var result = await localizationQueryService.GetAllAsync(localizationQuery, cancellationToken);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}
