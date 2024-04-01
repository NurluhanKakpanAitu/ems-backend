using Application.Dto.Dictionary.Localization;
using Application.Exception;
using Application.Interfaces;
using Application.Specifications.Dictionary;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Query.Impl;

public class LocalizationQueryService(IQueryRepository<Localization> localizationQueryRepository)
    : ILocalizationQueryService
{
    public async Task<List<Localization>> GetAllAsync(LocalizationQuery query,
        CancellationToken cancellationToken = default)
    {
        var spec = new LocalizationSpecification()
            .ByQuery(query);
        var result = await localizationQueryRepository.ListAsync(spec, cancellationToken);
        return result;
    }

    public async Task<Localization> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await localizationQueryRepository.GetByIdAsync(id, cancellationToken);
        if(result == null)
            throw new ApiException("Localization not found");
        return result;
    }
}