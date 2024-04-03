using Application.Dto.UserManager;

namespace Application.Dto.User;

public class UserGetDto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public DateTime BirthDate { get; set; }

    public IList<string> Roles { get; set; } = [];
    
    public List<GetClaimDto> Permissions { get; set; } = [];
}