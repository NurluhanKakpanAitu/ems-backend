namespace Domain.Entity;

public class TranslationBaseEntity
{
    public string? En { get; set; }

    public string? Ru { get; set; }

    public string? Kk { get; set; }

    public bool AllEmptyOrNull()
    {
       return string.IsNullOrEmpty(En) && string.IsNullOrEmpty(Ru) && string.IsNullOrEmpty(En);
    }
}