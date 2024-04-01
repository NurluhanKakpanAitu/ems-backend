using Domain.Entity;

namespace Application.Dto.Dictionary.QuestionType;

public class QuestionTypeCreateDto
{
    public required TranslationBaseEntity Title { get; set; }
    
    public required string Value { get; set; }
    
    public bool EmptyValue  => string.IsNullOrEmpty(Value);
}