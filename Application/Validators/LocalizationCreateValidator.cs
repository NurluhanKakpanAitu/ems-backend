using Application.Dto.Dictionary.Localization;
using FluentValidation;

namespace Application.Validators;

public class LocalizationCreateValidator : AbstractValidator<LocalizationCreateDto>
{
    public LocalizationCreateValidator()
    {
        RuleFor(q => q.Code)
            .NotNull()
            .WithMessage("Code is required")
            .NotEmpty()
            .WithMessage("Code is required");

        RuleFor(q => q.Description)
            .MaximumLength(1000)
            .WithMessage("Description is too long");
        
        RuleFor(q=>q.En)
            .MaximumLength(100)
            .WithMessage("En is too long");
        
        RuleFor(q=>q.Ru)
            .MaximumLength(100)
            .WithMessage("Ru is too long");
        
        RuleFor(q=>q.Kk)
            .MaximumLength(100)
            .WithMessage("Kk is too long");
    }
}