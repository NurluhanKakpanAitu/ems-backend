using Application.Dto.Dictionary.QuestionType;
using AutoMapper;
using Domain.Entity.Dictionary;

namespace Application.Mappings.Dictionary;

public class QuestionTypeMapping : Profile
{
    public QuestionTypeMapping()
    {
        MapCreateDto();
        MapUpdateDto();
    }
    
    private void MapCreateDto()
    {
        CreateMap<QuestionTypeCreateDto, QuestionType>()
            .ForMember(q => q.Id, src => Guid.NewGuid())
            .ForMember(q => q.Value, src => src.MapFrom(q => q.Value))
            .ForMember(q => q.Title, src => src.MapFrom(q => q.Title));
    }
    
    private void MapUpdateDto()
    {
        CreateMap<QuestionTypeUpdateDto, QuestionType>()
            .ForMember(q => q.Id,
                src => src.Ignore())
            .ForMember(q => q.Value, src => src.MapFrom(q => q.Value))
            .ForMember(q => q.Title, src => src.MapFrom(q => q.Title));
    }
}