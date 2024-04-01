using Application.Dto.Dictionary.QuizType;
using Application.Services.Dictionary.Command;
using Application.Services.Dictionary.Query;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.Dictionary;

[ApiController]
[Route("api/[controller]")]
public class QuizTypeController(
    IQuizTypeCommandService quizTypeCommandService,
    IQuizTypeQueryService quizTypeQueryService)
    : Controller
{
    /// <summary>
    /// Create new QuizType
    /// </summary>
    /// <param name="createDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    
    [HttpPost("create")]
    [ProducesResponseType(200, Type = typeof(Ok))]
    [ProducesResponseType(400, Type = typeof(BadRequestResult))]
    [ProducesResponseType(401,Type = typeof(UnauthorizedResult))]
    [ProducesResponseType(403,Type = typeof(ForbidResult))]
    public async Task<IActionResult> Create([FromBody] QuizTypeCreateDto createDto, CancellationToken cancellationToken)
    {
        await quizTypeCommandService.CreateAsync(createDto, cancellationToken);
        return Ok();
    }
    
    [HttpPut("update/{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] QuizTypeUpdateDto updateDto, CancellationToken cancellationToken)
    {
        await quizTypeCommandService.UpdateAsync(id, updateDto, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("delete/{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await quizTypeCommandService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
    
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAll([FromQuery] QuizTypeQuery query, CancellationToken cancellationToken)
    {
        var response = await quizTypeQueryService.GetAllAsync(query, cancellationToken);
        return Ok(response);
    }
    
    [HttpGet("get/{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await quizTypeQueryService.GetByIdAsync(id, cancellationToken);
        return Ok(response);
    }
}