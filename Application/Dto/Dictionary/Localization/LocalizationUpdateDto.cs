namespace Application.Dto.Dictionary.Localization;

public class LocalizationUpdateDto
{
    public required string Code { get; set; }
    
    public  string? En { get; set; }
    
    public  string? Ru { get; set; }
    
    public  string? Kk { get; set; }

    public string? Description { get; set; }
    
    public bool AllEmpty => string.IsNullOrEmpty(En) && string.IsNullOrEmpty(Ru) && string.IsNullOrEmpty(Kk);
}