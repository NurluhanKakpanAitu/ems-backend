using Application.Dto.Auth;
using Application.Services.Account.Command;
using Application.Services.Account.Query;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.Auth;

[ApiController]
[Route("api/[controller]")]
public class AccountController(
    IAccountCommandService accountCommandService,
    IAccountQueryService accountQueryService
    ) : Controller
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await accountCommandService.Login(loginDto);
        return Ok(result);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        await accountCommandService.RegisterUser(registerDto);
        return Ok("User registered");
    }
    
    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
    {
        await accountCommandService.ChangePassword(changePasswordDto);
        return Ok("Password changed");
    }
    
    [HttpGet("profile")]
    public async Task<IActionResult> Profile()
    {
        var user = await accountQueryService.GetUserByTokenAsync();
        return Ok(user);
    }
    
}