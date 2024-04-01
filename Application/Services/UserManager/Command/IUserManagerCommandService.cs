using Application.Dto.UserManager;

namespace Application.Services.UserManager.Command;

public interface IUserManagerCommandService
{
    Task CreateRole(CreateRoleDto createRoleDto, CancellationToken cancellationToken);
    
    Task CreatePermission(CreatePermissionDto createPermissionDto, CancellationToken cancellationToken);
    
    Task ChangeRole(ChangeRoleDto changeRoleDto, CancellationToken cancellationToken);
    
    Task ChangePermission(ChangePermissionDto changePermissionDto, CancellationToken cancellationToken);
    
    Task DeleteRole(string roleId, CancellationToken cancellationToken);
    
    Task DeletePermission(DeletePermissionDto deletePermissionDto, CancellationToken cancellationToken);
}