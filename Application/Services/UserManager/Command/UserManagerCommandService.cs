using System.Security.Claims;
using Application.Dto.UserManager;
using Application.Exception;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.UserManager.Command;

public class UserManagerCommandService(RoleManager<IdentityRole> roleManager) : IUserManagerCommandService
{
    public async Task CreateRole(CreateRoleDto createRoleDto,CancellationToken cancellationToken)
    {
        var exists = await roleManager.RoleExistsAsync(createRoleDto.RoleName);
        if(exists)
            throw new ApiException("Role already exists");
        var role = new IdentityRole(createRoleDto.RoleName);
        await roleManager.CreateAsync(role);
    }

    public async Task CreatePermission(CreatePermissionDto createPermissionDto, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByNameAsync(createPermissionDto.RoleName);
        if(role == null)
            throw new ApiException("Role not found");
        await roleManager.AddClaimAsync(role, new Claim("Permission", createPermissionDto.PermissionName));
    }

    public async Task ChangeRole(ChangeRoleDto changeRoleDto, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByNameAsync(changeRoleDto.OldRoleName);
        if(role == null)
            throw new ApiException("Role not found");
        role.Name = changeRoleDto.NewRoleName;
        await roleManager.UpdateAsync(role);
    }

    public async Task ChangePermission(ChangePermissionDto changePermissionDto, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByNameAsync(changePermissionDto.RoleName);
        if(role == null)
            throw new ApiException("Role not found");
        var claims = await roleManager.GetClaimsAsync(role);
        var claim = claims.FirstOrDefault(c => c.Value == changePermissionDto.OldPermissionName);
        if(claim == null)
            throw new ApiException("Permission not found");
        await roleManager.RemoveClaimAsync(role, claim);
        await roleManager.AddClaimAsync(role, new Claim("Permission", changePermissionDto.NewPermissionName));
    }

    public async Task DeleteRole(string roleId, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByIdAsync(roleId);
        if(role == null)
            throw new ApiException("Role not found");
        await roleManager.DeleteAsync(role);
    }

    public async Task DeletePermission(DeletePermissionDto deletePermissionDto, CancellationToken cancellationToken)
    {
        var role = await roleManager.FindByIdAsync(deletePermissionDto.RoleId);
        if(role == null)
            throw new ApiException("Role not found");
        var claims = await roleManager.GetClaimsAsync(role);
        var claim = claims.FirstOrDefault(c => c.Value == deletePermissionDto.PermissionName);
        if(claim == null)
            throw new ApiException("Permission not found");
        await roleManager.RemoveClaimAsync(role, claim);
    }
}