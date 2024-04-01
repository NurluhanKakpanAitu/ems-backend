using Application.Dto.Dictionary.Subject;
using Application.Services.Dictionary.Command;
using Application.Services.Dictionary.Query;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.Dictionary;

[ApiController]
[Route("api/[controller]")]
public class SubjectController(
    ISubjectCommandService subjectCommandService,
    ISubjectQueryService subjectQueryService)
    : Controller
{
    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAll([FromQuery] SubjectQuery query, CancellationToken cancellationToken = default)
    {
        var result = await subjectQueryService.GetAllAsync(query, cancellationToken);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("get/{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var result = await subjectQueryService.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] SubjectCreateDto dto, CancellationToken cancellationToken = default)
    {
        await subjectCommandService.CreateAsync(dto, cancellationToken);
        return Ok();
    }
    
    [HttpPut]
    [Route("update/{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SubjectUpdateDto dto, CancellationToken cancellationToken = default)
    {
        await subjectCommandService.UpdateAsync(id, dto, cancellationToken);
        return Ok();
    }
    
    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        await subjectCommandService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
    
}