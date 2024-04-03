using Application.Dto.User;
using Application.Exception;
using AutoMapper;
using Domain.Entity.User;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.User.Command;

public class UserCommandService(
    UserManager<AppUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IMapper mapper)
    : IUserCommandService
{
    public async Task CreateAsync(UserCreateDto userCreateDto)
    {
        var existingUserByEmail = await userManager.FindByEmailAsync(userCreateDto.Email);
        if (existingUserByEmail != null)
            throw new ApiException("Пользователь с таким Email уже существует");
        
        var existingUserByUserName = await userManager.FindByNameAsync(userCreateDto.UserName);
        if(existingUserByUserName != null)
            throw new ApiException("Пользователь с таким UserName уже существует");
        
        var existRole = await roleManager.FindByNameAsync(userCreateDto.Role);
        if (existRole == null)
            throw new ApiException("Роль не найдена");
        
        var user = mapper.Map<AppUser>(userCreateDto);
        var result = await userManager.CreateAsync(user, userCreateDto.Password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, userCreateDto.Role);
        }
    }

    public async Task UpdateAsync(string id,UserUpdateDto userUpdateDto)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
            throw new ApiException("Пользователь не найден");
        
        var existingUserByEmail = await userManager.FindByEmailAsync(userUpdateDto.Email);
        if (existingUserByEmail != null && existingUserByEmail.Id != id)
            throw new ApiException("Пользователь с таким Email уже существует");
        
        var existingUserByUserName = await userManager.FindByNameAsync(userUpdateDto.UserName);
        if(existingUserByUserName != null && existingUserByUserName.Id != id)
            throw new ApiException("Пользователь с таким UserName уже существует");
        
        var existRole = await roleManager.FindByNameAsync(userUpdateDto.Role);
        if (existRole == null)
            throw new ApiException("Роль не найдена");
        var userUpdate = mapper.Map(userUpdateDto, user);
        await userManager.UpdateAsync(userUpdate);
        await userManager.RemoveFromRoleAsync(user, userUpdateDto.Role);
        await userManager.AddToRoleAsync(userUpdate, userUpdateDto.Role);
    }

    public async Task DeleteAsync(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if (user == null)
            throw new ApiException("Пользователь не найден");
        await userManager.DeleteAsync(user);
        var roles = await userManager.GetRolesAsync(user);
        await userManager.RemoveFromRolesAsync(user, roles);
    }
}