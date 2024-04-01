using System.Security.Claims;
using Application.Dto.Auth;
using Application.Exception;
using AutoMapper;
using Domain.Entity.User;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Account.Command.Impl;

public class AccountCommandService(
    SignInManager<AppUser> signInManager,
    UserManager<AppUser> userManager,
    TokenService tokenService,
    IMapper mapper,
    IHttpContextAccessor httpContextAccessor
    )
    : IAccountCommandService
{

    public async Task RegisterUser(RegisterDto registerUserDto)
    {
        var userByName = await userManager.FindByNameAsync(registerUserDto.UserName);
        if(userByName != null)
            throw new ApiException("User already exists");
        var userByEmail = await userManager.FindByEmailAsync(registerUserDto.Email);
        if(userByEmail != null)
            throw new ApiException("Email already exists");
        var newUser = mapper.Map<AppUser>(registerUserDto);
        var userResult = await userManager.CreateAsync(newUser, registerUserDto.Password);
        var roleResult = await userManager.AddToRoleAsync(newUser, Roles.User.ToString());
        if(!userResult.Succeeded || !roleResult.Succeeded)
            throw new ApiException("User creation failed");
    }

    public async Task<TokenDto> Login(LoginDto loginDto)
    {
        var user = await userManager.FindByNameAsync(loginDto.UserName);
        if(user == null)
            throw new ApiException("User not found");
        if(user.Email != loginDto.Email)
            throw new ApiException("Invalid Email");
        
        var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (!result.Succeeded)
            throw new ApiException("Invalid Password");
        var roles = await userManager.GetRolesAsync(user);
        var token = tokenService.GetToken(user, roles);
        return token;
    }
    
    public async Task ChangePassword(ChangePasswordDto changePasswordDto)
    {
        var userName = httpContextAccessor.HttpContext?.User.FindFirst(q=>q.Type == ClaimTypes.NameIdentifier)?.Value;
        if(userName == null)
            throw new ApiException("User not found");
        var appUser = await userManager.FindByNameAsync(userName);
        if(appUser == null)
            throw new ApiException("User not found");
        var result = await userManager.ChangePasswordAsync(appUser, changePasswordDto.OldPassword, changePasswordDto.NewPassword);
        if(!result.Succeeded)
            throw new ApiException("Password change failed");
    }
    
    
}