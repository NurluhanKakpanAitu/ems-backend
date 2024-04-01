using Application.Dto.UserManager;
using Application.Services.UserManager.Command;
using Application.Services.UserManager.Query;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.UserManager;

[ApiController]
[Route("api/[controller]")]
public class UserManagerController(
    IUserManagerCommandService userManagerCommandService,
    IUserManagerQueryService userManagerQueryService
    ) : Controller
{
    
    [HttpPost("create-role")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto createRoleDto, CancellationToken cancellationToken)
    {
        await userManagerCommandService.CreateRole(createRoleDto, cancellationToken);
        return Ok();
    }
    
    [HttpPost("create-permission")]
    public async Task<IActionResult> CreatePermission([FromBody] CreatePermissionDto createPermissionDto, CancellationToken cancellationToken)
    {
        await userManagerCommandService.CreatePermission(createPermissionDto, cancellationToken);
        return Ok();
    }
    
    [HttpPost("change-role")]
    public async Task<IActionResult> ChangeRole([FromBody] ChangeRoleDto changeRoleDto, CancellationToken cancellationToken)
    {
        await userManagerCommandService.ChangeRole(changeRoleDto, cancellationToken);
        return Ok();
    }
    
    [HttpPost("change-permission")]
    public async Task<IActionResult> ChangePermission([FromBody] ChangePermissionDto changePermissionDto, CancellationToken cancellationToken)
    {
        await userManagerCommandService.ChangePermission(changePermissionDto, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("delete-role/{roleId}")]
    public async Task<IActionResult> DeleteRole([FromRoute] string roleId, CancellationToken cancellationToken)
    {
        await userManagerCommandService.DeleteRole(roleId, cancellationToken);
        return Ok();
    }
    
    [HttpDelete("delete-permission")]
    public async Task<IActionResult> DeletePermission([FromBody] DeletePermissionDto deletePermissionDto, CancellationToken cancellationToken)
    {
        await userManagerCommandService.DeletePermission(deletePermissionDto, cancellationToken);
        return Ok();
    }
    
    [HttpGet("get-roles")]
    public async Task<IActionResult> GetRoles()
    {
        var roles = await userManagerQueryService.GetRolesAsync();
        return Ok(roles);
    }
    
    [HttpGet("get-role/{roleId}")]
    public async Task<IActionResult> GetRole([FromRoute] string roleId)
    {
        var role = await userManagerQueryService.GetRoleByIdAsync(roleId);
        return Ok(role);
    }
    
    [HttpGet("get-permissions")]
    public async Task<IActionResult> GetPermissions()
    {
        var permissions = await userManagerQueryService.GetPermissionsAsync();
        return Ok(permissions);
    }
    
    [HttpGet("get-permission/{permissionName}")]
    public async Task<IActionResult> GetPermission([FromRoute] string permissionName)
    {
        var permission = await userManagerQueryService.GetPermissionByNameAsync(permissionName);
        return Ok(permission);
    }
    
}