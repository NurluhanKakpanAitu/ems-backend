using System.Security.Claims;
using Application.Dto.User;
using Application.Dto.UserManager;
using Application.Exception;
using AutoMapper;
using Domain.Entity.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Account.Query.Impl;

public class AccountQueryService(
    IHttpContextAccessor httpContextAccessor,
    UserManager<AppUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IMapper mapper
    ) : IAccountQueryService
{
    public async Task<ProfileDto> GetUserByTokenAsync()
    {
        var username = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if(username == null)
            throw new ApiException("User not found");
        
        var user = await userManager.FindByNameAsync(username);
        if(user == null)
            throw new ApiException("User not found");
        var profileDto = mapper.Map<ProfileDto>(user);
        var roles = await userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            var roleEntity = await roleManager.FindByNameAsync(role);
            if(roleEntity == null)
                continue;
            var permissions = await roleManager.GetClaimsAsync(roleEntity);
            var claims = mapper.Map<List<GetClaimDto>>(permissions);
            profileDto.Permissions.AddRange(claims);
        }
        profileDto.Roles = roles;
        return profileDto;
    }
}