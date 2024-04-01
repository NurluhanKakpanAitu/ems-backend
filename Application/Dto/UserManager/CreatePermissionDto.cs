namespace Application.Dto.UserManager;

public class CreatePermissionDto
{
    public required string RoleName { get; set; }
    public required string PermissionName { get; set; }
}