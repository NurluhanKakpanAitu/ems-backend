using Application.Dto.Auth;
using Application.Dto.User;
using AutoMapper;
using Domain.Entity.User;

namespace Application.Mappings.User;

public class UserMapping : Profile
{
    public UserMapping()
    {
        RegisterMapping();
        ProfileMapping();
        CreateMapping();
        UserListMapping();
        UserGetMapping();
    }

    private void RegisterMapping()
    {
        CreateMap<RegisterDto, AppUser>()
            .ForMember(q => q.Id, src => Guid.NewGuid())
            .ForMember(q => q.UserName, src => src.MapFrom(q => q.UserName))
            .ForMember(q => q.Email, src => src.MapFrom(q => q.Email))
            .ForMember(q => q.FirstName, src => src.MapFrom(q => q.FirstName))
            .ForMember(q => q.LastName, src => src.MapFrom(q => q.LastName));
    }

    private void ProfileMapping()
    {
        CreateMap<AppUser, ProfileDto>()
            .ForMember(q=> q.FirstName, src => src.MapFrom(q => q.FirstName))
            .ForMember(q=> q.LastName, src => src.MapFrom(q => q.LastName))
            .ForMember(q=> q.Email, src => src.MapFrom(q => q.Email))
            .ForMember(q=> q.UserName, src => src.MapFrom(q => q.UserName))
            .ForMember(q=> q.BirthDate, src => src.MapFrom(q => q.BirthDate))
            .ForMember(q=> q.Roles, src => src.Ignore())
            .ForMember(q=> q.Permissions, src => src.Ignore());
    }

    private void CreateMapping()
    {
        CreateMap<UserCreateDto, AppUser>()
            .ForMember(q => q.Id, src => src.MapFrom(q => Guid.NewGuid()))
            .ForMember(q => q.UserName, src => src.MapFrom(q => q.UserName))
            .ForMember(q => q.Email, src => src.MapFrom(q => q.Email))
            .ForMember(q => q.FirstName, src => src.MapFrom(q => q.FirstName))
            .ForMember(q => q.LastName, src => src.MapFrom(q => q.LastName))
            .ForMember(q => q.BirthDate, src => src.MapFrom(q => q.DateOfBirth));
    }

    private void UserListMapping()
    {
        CreateMap<AppUser, UserListDto>()
            .ForMember(q=> q.Id, src => src.MapFrom(q => q.Id))
            .ForMember(q=> q.FirstName, src => src.MapFrom(q => q.FirstName))
            .ForMember(q=> q.LastName, src => src.MapFrom(q => q.LastName))
            .ForMember(q=> q.Email, src => src.MapFrom(q => q.Email))
            .ForMember(q=> q.UserName, src => src.MapFrom(q => q.UserName))
            .ForMember(q=> q.DateOfBirth, src => src.MapFrom(q => q.BirthDate));
    }

    private void UserGetMapping()
    {
        CreateMap<AppUser,UserGetDto>()
            .ForMember(q=> q.FirstName, src => src.MapFrom(q => q.FirstName))
            .ForMember(q=> q.LastName, src => src.MapFrom(q => q.LastName))
            .ForMember(q=> q.Email, src => src.MapFrom(q => q.Email))
            .ForMember(q=> q.UserName, src => src.MapFrom(q => q.UserName))
            .ForMember(q=> q.BirthDate, src => src.MapFrom(q => q.BirthDate))
            .ForMember(q=> q.Roles, src => src.Ignore())
            .ForMember(q=> q.Permissions, src => src.Ignore());
    }
}