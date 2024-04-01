using Microsoft.AspNetCore.Identity;
namespace Domain.Entity.User;


public class AppUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    public DateTime? BirthDate { get; set; }
}