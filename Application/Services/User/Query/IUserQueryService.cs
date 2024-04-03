using Application.Dto.Response;
using Application.Dto.User;

namespace Application.Services.User.Query;

public interface IUserQueryService
{
    Task<PageableResponse<UserListDto>> GetUsersAsync(UserSearchQueryDto query);
    
    Task<UserGetDto> GetUserAsync(string userId);
}