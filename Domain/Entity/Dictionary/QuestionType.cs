namespace Domain.Entity.Dictionary;

public class QuestionType : BaseEntity
{
    public Guid CreatedUserId { get; set; }

    public Guid UpdatedUserId { get; set; }
    
    public required TranslationBaseEntity Title { get; set; }

    public required string Value { get; set; }
}