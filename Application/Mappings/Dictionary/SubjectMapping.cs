using Application.Dto.Dictionary.Subject;
using AutoMapper;
using Domain.Entity.Dictionary;

namespace Application.Mappings.Dictionary;

public class SubjectMapping : Profile
{
    public SubjectMapping()
    {
        MapCreateDto();
        MapUpdateDto();
    }
    private void MapCreateDto()
    {
        CreateMap<SubjectCreateDto, Subject>()
            .ForMember(q=>q.Id, opt=>Guid.NewGuid())
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
    }
    private void MapUpdateDto()
    {
        CreateMap<SubjectUpdateDto, Subject>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
    }
}