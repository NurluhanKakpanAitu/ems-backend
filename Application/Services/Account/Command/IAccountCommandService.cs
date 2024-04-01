using Application.Dto.Auth;
namespace Application.Services.Account.Command;

public interface IAccountCommandService
{
    Task RegisterUser(RegisterDto registerUserDto);
    
    Task<TokenDto> Login(LoginDto loginDto);
    
    Task ChangePassword(ChangePasswordDto changePasswordDto);
    
}
