using Application.Dto.UserManager;
using Application.Exception;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.UserManager.Query;

public class UserManagerQueryService(RoleManager<IdentityRole> roleManager) : IUserManagerQueryService
{
    public async Task<List<GetRoleDto>> GetRolesAsync()
    {
        var roles = await roleManager.Roles.Select(r => new GetRoleDto
        {
            RoleId = r.Id,
            RoleName = r.Name ?? string.Empty
        }).ToListAsync();
        return roles;
    }

    public async Task<GetRoleDto> GetRoleByIdAsync(string roleId)
    {
        var role = await roleManager.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
        if(role == null)
            throw new ApiException("Role not found");
        var roleDto = new GetRoleDto
        {
            RoleId = role.Id,
            RoleName = role.Name ?? string.Empty
        };
        return roleDto;
    }

    public async Task<List<GetPermissionDto>> GetPermissionsAsync()
    {
        var roles = await roleManager.Roles.ToListAsync();
        var permissions = new List<GetPermissionDto>();
        foreach (var role in roles)
        {
            var claims = await roleManager.GetClaimsAsync(role);
            permissions.AddRange(from claim in claims where claim.Type == "Permission" select new GetPermissionDto { RoleId = role.Id, PermissionName = claim.Value });
        }
        return permissions;
    }

    public async Task<GetPermissionDto> GetPermissionByNameAsync(string permissionName)
    {
        var permissions = await GetPermissionsAsync();
        var permission = permissions.FirstOrDefault(p => p.PermissionName == permissionName);
        if(permission == null)
            throw new ApiException("Permission not found");
        return permission;
    }
}