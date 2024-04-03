namespace Application.Dto.User;

public class UserCreateDto
{
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public required string UserName { get; set; }
    
    public required string Email { get; set; }
    
    public required string Password { get; set; }
    
    public DateTime? DateOfBirth { get; set; }
    
    public required string Role { get; set; } 
}