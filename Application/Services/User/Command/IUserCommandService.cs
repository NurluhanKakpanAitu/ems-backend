using Application.Dto.User;

namespace Application.Services.User.Command;

public interface IUserCommandService
{
    Task CreateAsync(UserCreateDto userCreateDto);
    
    Task UpdateAsync(string id, UserUpdateDto userUpdateDto);
    
    Task DeleteAsync(string id);
}