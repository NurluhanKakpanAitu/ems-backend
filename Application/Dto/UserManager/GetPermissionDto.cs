namespace Application.Dto.UserManager;

public class GetPermissionDto
{
    public required string RoleId { get; set; }
    public required string PermissionName { get; set; }
    
}