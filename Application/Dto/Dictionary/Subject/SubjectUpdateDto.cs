using Domain.Entity;

namespace Application.Dto.Dictionary.Subject;

public class SubjectUpdateDto
{
    public required TranslationBaseEntity Title { get; set; }
}