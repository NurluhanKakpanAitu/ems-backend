namespace Application.Dto.UserManager;

public class ChangeRoleDto
{
    public required string OldRoleName { get; set; }
    public required string NewRoleName { get; set; }
}