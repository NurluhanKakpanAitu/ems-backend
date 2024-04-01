namespace Domain.Entity.Dictionary;

public class Localization : BaseEntity
{
    public required string Code { get; set; }
    
    public string? En { get; set; }

    public string? Ru { get; set; }

    public string? Kk { get; set; }

    public string? Description { get; set; }
}