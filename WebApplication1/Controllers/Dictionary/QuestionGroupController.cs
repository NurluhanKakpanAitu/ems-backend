using Application.Dto.Dictionary.QuestionGroup;
using Application.Services.Dictionary.Command;
using Application.Services.Dictionary.Query;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.Dictionary;

[ApiController]
[Route("api/[controller]")]
public class QuestionGroupController(
    IQuestionGroupCommandService questionGroupCommandService,
    IQuestionGroupQueryService questionGroupQueryService)
    : Controller
{
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] QuestionGroupCreateDto createDto, CancellationToken cancellationToken)
    {
        await questionGroupCommandService.CreateAsync(createDto, cancellationToken);
        return Ok();
    }
    
    [HttpPut("update/{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] QuestionGroupUpdateDto updateDto, CancellationToken cancellationToken)
    {
        await questionGroupCommandService.UpdateAsync(id, updateDto, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await questionGroupCommandService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
    
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll([FromQuery] QuestionGroupQuery query, CancellationToken cancellationToken)
    {
        var response = await questionGroupQueryService.GetAllAsync(query, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("get/{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await questionGroupQueryService.GetByIdAsync(id, cancellationToken);
        return Ok(response);
    }
}