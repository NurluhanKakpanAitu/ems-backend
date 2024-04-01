namespace Application.Dto.UserManager;

public class ChangePermissionDto
{
    public required string RoleName { get; set; }
    
    public required string OldPermissionName { get; set; }
    
    public required string NewPermissionName { get; set; }
}