using Application.Dto.Dictionary.QuestionGroup;
using AutoMapper;
using Domain.Entity.Dictionary;

namespace Application.Mappings.Dictionary;

public class QuestionGroupMapping : Profile
{
    public QuestionGroupMapping()
    {
        MapCreateDto();
        MapUpdateDto();
    }

    private void MapCreateDto()
    {
        CreateMap<QuestionGroupCreateDto, QuestionGroup>()
            .ForMember(q => q.Id, src => Guid.NewGuid())
            .ForMember(q => q.Title,
                src => src.MapFrom(q => q.Title));
    }
    
    private void MapUpdateDto()
    {
        CreateMap<QuestionGroupUpdateDto, QuestionGroup>()
            .ForMember(q => q.Id, src => src.Ignore())
            .ForMember(q => q.Title,
                src => src.MapFrom(q => q.Title));
    }
}