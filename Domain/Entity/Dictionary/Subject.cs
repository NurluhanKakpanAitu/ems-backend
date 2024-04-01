namespace Domain.Entity.Dictionary;

public class Subject : BaseEntity
{
    public Guid CreatedUserId { get; set; }

    public Guid UpdatedUserId { get; set; }

    public required TranslationBaseEntity Title { get; set; }
}