using Domain.Entity;

namespace Application.Dto.Dictionary.QuizType;

public class QuizTypeCreateDto
{
    public required TranslationBaseEntity Title { get; set; }
}