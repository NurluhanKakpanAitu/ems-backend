using Application.Dto.Dictionary.Localization;
using Application.Exception;
using Application.Interfaces;
using Application.Specifications.Dictionary;
using Application.Validators;
using AutoMapper;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Command.Impl;

public class LocalizationCommandService(IAsyncRepository<Localization> localizationAsyncRepository, IMapper mapper)
    : ILocalizationCommandService
{
    public async Task Create(LocalizationCreateDto localizationCreateDto, CancellationToken cancellationToken)
    {
        var validator = new LocalizationCreateValidator();
        var result = await validator.ValidateAsync(localizationCreateDto, cancellationToken);
        if (!result.IsValid)
            throw new ApiException(result.Errors.First().ErrorMessage);
        
        if(localizationCreateDto.AllEmpty)
            throw new ApiException("At least one language should be filled");

        await ExistLocalization(localizationCreateDto.Code, cancellationToken);
        
        var localization = mapper.Map<Localization>(localizationCreateDto);
        
        await localizationAsyncRepository.AddAsync(localization, cancellationToken);
    }

    public async Task Update(Guid id, LocalizationUpdateDto localizationUpdateDto, CancellationToken cancellationToken)
    {
        var validator = new LocalizationUpdateValidator();
        var result = await validator.ValidateAsync(localizationUpdateDto, cancellationToken);
        if (!result.IsValid)
            throw new ApiException(result.Errors.First().ErrorMessage);
        
        if(localizationUpdateDto.AllEmpty)
            throw new ApiException("At least one language should be filled");
        
        var localization = await localizationAsyncRepository.GetByIdAsync(id, cancellationToken);
        if (localization == null)
            throw new ApiException("Localization not found");
        
        mapper.Map(localizationUpdateDto, localization);
        
        await localizationAsyncRepository.UpdateAsync(localization, cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var localization = await localizationAsyncRepository.GetByIdAsync(id, cancellationToken);
        if (localization == null)
            throw new ApiException("Localization not found");
        
        await localizationAsyncRepository.DeleteAsync(localization, cancellationToken);
    }
    
    private async Task ExistLocalization(string code, CancellationToken cancellationToken)
    {
        var spec = new LocalizationSpecification().ByCode(code);
        var existAsync = await localizationAsyncRepository.ExistAsync(spec, cancellationToken);
        if (existAsync)
            throw new ApiException("Localization with this code already exists");
    }
}