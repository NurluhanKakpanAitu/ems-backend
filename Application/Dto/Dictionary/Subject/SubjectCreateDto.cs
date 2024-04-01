using Domain.Entity;

namespace Application.Dto.Dictionary.Subject;

public class SubjectCreateDto
{
    public required TranslationBaseEntity Title { get; set; }
}