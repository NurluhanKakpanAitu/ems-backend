using Application.Dto.Dictionary.QuestionType;
using Application.Services.Dictionary.Command;
using Application.Services.Dictionary.Query;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.Dictionary;

[ApiController]
[Route("api/[controller]")]
public class QuestionTypeController : Controller
{
    private readonly IQuestionTypeCommandService _questionTypeCommandService;
    private readonly IQuestionTypeQueryService _questionTypeQueryService;
 
    public QuestionTypeController(
        IQuestionTypeCommandService questionTypeCommandService, 
        IQuestionTypeQueryService questionTypeQueryService)
    {
        _questionTypeCommandService = questionTypeCommandService;
        _questionTypeQueryService = questionTypeQueryService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] QuestionTypeCreateDto createDto, CancellationToken cancellationToken)
    {
        await _questionTypeCommandService.CreateAsync(createDto, cancellationToken);
        return Ok();
    }
    
    [HttpPut("update/{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] QuestionTypeUpdateDto updateDto, CancellationToken cancellationToken)
    {
        await _questionTypeCommandService.UpdateAsync(id, updateDto, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _questionTypeCommandService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
    
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll([FromQuery] QuestionTypeQuery queryDto, CancellationToken cancellationToken)
    {
        var response = await _questionTypeQueryService.GetAllAsync(queryDto, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("get/{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await _questionTypeQueryService.GetByIdAsync(id, cancellationToken);
        return Ok(response);
    }
}