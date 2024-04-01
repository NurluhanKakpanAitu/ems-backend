using System.Security.Claims;
using Application.Dto.UserManager;
using AutoMapper;

namespace Application.Mappings.UserManager;

public class PermissionMapping : Profile
{
    public PermissionMapping()
    {
        ProfileMapping();
    }

    private void ProfileMapping()
    {
        CreateMap<Claim, GetClaimDto>()
            .ForMember(q => q.Type, opt => opt.MapFrom(q => q.Type))
            .ForMember(q=> q.Value, opt => opt.MapFrom(q => q.Value));
    }
}