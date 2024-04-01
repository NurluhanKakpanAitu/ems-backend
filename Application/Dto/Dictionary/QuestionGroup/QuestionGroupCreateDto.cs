using Domain.Entity;

namespace Application.Dto.Dictionary.QuestionGroup;

public class QuestionGroupCreateDto
{
    public required TranslationBaseEntity Title { get; set; }
}