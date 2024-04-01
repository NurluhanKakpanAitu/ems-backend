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
}