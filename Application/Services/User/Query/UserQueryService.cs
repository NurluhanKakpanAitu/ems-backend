using Application.Dto.Response;
using Application.Dto.User;
using Application.Dto.UserManager;
using Application.Exception;
using AutoMapper;
using Domain.Entity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.User.Query;

public class UserQueryService : IUserQueryService
{
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;

    public UserQueryService(IMapper mapper, UserManager<AppUser> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<PageableResponse<UserListDto>> GetUsersAsync(UserSearchQueryDto query)
    {
        var users = await _userManager.Users
            .Where(x => string.IsNullOrEmpty(query.Search) || x.UserName!.Contains(query.Search) || x.Email!.Contains(query.Search) || x.FirstName!.Contains(query.Search) || x.LastName!.Contains(query.Search))
            .Select(x => _mapper.Map<UserListDto>(x))
            .ToListAsync();
        
        var paginatedUsers = users.Skip(query.PageSize * (query.PageNumber - 1)).Take(query.PageSize).ToList();
        return new PageableResponse<UserListDto>(paginatedUsers, query.PageNumber, query.PageSize, users.Count);
    }

    public async Task<UserGetDto> GetUserAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            throw new ApiException("Пользователь не найден");

        var userDto = _mapper.Map<UserGetDto>(user);
        userDto.Roles = await _userManager.GetRolesAsync(user);
        var userClaims = await _userManager.GetClaimsAsync(user);
        userDto.Permissions = _mapper.Map<List<GetClaimDto>>(userClaims);
        return userDto;
    }
}