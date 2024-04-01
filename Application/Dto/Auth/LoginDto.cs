namespace Application.Dto.Auth;

public class LoginDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string UserName { get; set; }
}