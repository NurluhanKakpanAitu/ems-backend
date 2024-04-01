using Application.Dto.Dictionary.QuizType;
using AutoMapper;
using Domain.Entity.Dictionary;

namespace Application.Mappings.Dictionary;

public class QuizTypeMapping : Profile
{
    public QuizTypeMapping()
    {
        MapCreateDto();
        MapUpdateDto();
    }
    
    private void MapCreateDto()
    {
        CreateMap<QuizTypeCreateDto, QuizType>()
            .ForMember(q => q.Id, src => Guid.NewGuid())
            .ForMember(q => q.Title,
                src => src.MapFrom(q => q.Title));
    }
    
    private void MapUpdateDto()
    {
        CreateMap<QuizTypeUpdateDto, QuizType>()
            .ForMember(q => q.Id,
                src => src.Ignore())
            .ForMember(q => q.Title,
                src => src.MapFrom(q => q.Title));
    }
    
}