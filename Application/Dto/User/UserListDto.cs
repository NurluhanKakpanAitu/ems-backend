namespace Application.Dto.User;

public class UserListDto
{
    public required string Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}