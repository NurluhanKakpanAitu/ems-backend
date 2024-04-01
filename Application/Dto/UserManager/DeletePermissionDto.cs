namespace Application.Dto.UserManager;

public class DeletePermissionDto
{
    public required string  RoleId { get; set; }
    public required string PermissionName { get; set; }
}