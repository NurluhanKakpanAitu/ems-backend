using Domain.Entity;

namespace Application.Dto.Dictionary.QuizType;

public class QuizTypeUpdateDto
{
    public required TranslationBaseEntity Title { get; set; }
}