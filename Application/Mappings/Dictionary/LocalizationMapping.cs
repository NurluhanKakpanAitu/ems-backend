using Application.Dto.Dictionary.Localization;
using AutoMapper;
using Domain.Entity.Dictionary;

namespace Application.Mappings.Dictionary;

public class LocalizationMapping : Profile
{
    public LocalizationMapping()
    {
        CreateMapping();
        UpdateMapping();
    }
    
    private void CreateMapping()
    {
        CreateMap<LocalizationCreateDto, Localization>()
            .ForMember(q => q.Id, src => Guid.NewGuid())
            .ForMember(q => q.Code,
                src => src.MapFrom(q => q.Code))
            .ForMember(q => q.Description,
                src => src.MapFrom(q => q.Description))
            .ForMember(q => q.En,
                src => src.MapFrom(q => q.En))
            .ForMember(q => q.Ru,
                src => src.MapFrom(q => q.Ru))
            .ForMember(q => q.Kk,
                src => src.MapFrom(q => q.Kk));
    }
    private void UpdateMapping()
    {
        CreateMap<LocalizationUpdateDto, Localization>()
            .ForMember(q => q.Id,
                src => src.Ignore())
            .ForMember(q => q.Code,
                src => src.MapFrom(q => q.Code))
            .ForMember(q => q.Description,
                src => src.MapFrom(q => q.Description))
            .ForMember(q => q.En,
                src => src.MapFrom(q => q.En))
            .ForMember(q => q.Ru,
                src => src.MapFrom(q => q.Ru))
            .ForMember(q => q.Kk,
                src => src.MapFrom(q => q.Kk));
    }
}