using Application.Dto.Dictionary.Localization;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Query;

public interface ILocalizationQueryService
{
    Task<List<Localization>> GetAllAsync(LocalizationQuery query,
        CancellationToken cancellationToken = default);
    
    Task<Localization> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}