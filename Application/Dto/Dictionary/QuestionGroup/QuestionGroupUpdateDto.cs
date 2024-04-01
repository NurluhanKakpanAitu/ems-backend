using Domain.Entity;

namespace Application.Dto.Dictionary.QuestionGroup;

public class QuestionGroupUpdateDto
{
    public required TranslationBaseEntity Title { get; set; }
}