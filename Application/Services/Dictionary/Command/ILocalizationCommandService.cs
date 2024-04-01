using Application.Dto.Dictionary.Localization;

namespace Application.Services.Dictionary.Command;

public interface ILocalizationCommandService
{
    Task Create(LocalizationCreateDto localizationCreateDto, CancellationToken cancellationToken);

    Task Update(Guid id, LocalizationUpdateDto localizationUpdateDto, CancellationToken cancellationToken);
    
    Task Delete(Guid id, CancellationToken cancellationToken);
}