using Application.Dto.User;
using Application.Services.User.Command;
using Application.Services.User.Query;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.User;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserQueryService _userQueryService;
    private readonly IUserCommandService _userCommandService; 

    public UserController(IUserQueryService userQueryService, IUserCommandService userCommandService)
    {
        _userQueryService = userQueryService;
        _userCommandService = userCommandService;
    }
    
    
    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAllAsync([FromQuery] UserSearchQueryDto query)
    {
        var users = await _userQueryService.GetUsersAsync(query);
        return Ok(users);
    }
    
    [HttpGet]
    [Route("get/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
    {
        var user = await _userQueryService.GetUserAsync(id);
        return Ok(user);
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateAsync([FromBody] UserCreateDto createDto)
    {
        await _userCommandService.CreateAsync(createDto);
        return Ok();
    }
    
    [HttpPut]
    [Route("update/{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] UserUpdateDto updateDto)
    {
        await _userCommandService.UpdateAsync(id, updateDto);
        return Ok();
    }
    
    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] string id)
    {
        await _userCommandService.DeleteAsync(id);
        return Ok();
    }
}