using Application.Dto.User;
namespace Application.Services.Account.Query;

public interface IAccountQueryService
{
    Task<ProfileDto> GetUserByTokenAsync();
}