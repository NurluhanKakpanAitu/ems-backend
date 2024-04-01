using Application.Dto.UserManager;

namespace Application.Services.UserManager.Query;

public interface IUserManagerQueryService
{
    Task<List<GetRoleDto>> GetRolesAsync();
    
    Task<GetRoleDto> GetRoleByIdAsync(string roleId);
    
    Task<List<GetPermissionDto>> GetPermissionsAsync();
    
    Task<GetPermissionDto> GetPermissionByNameAsync(string permissionName);
}