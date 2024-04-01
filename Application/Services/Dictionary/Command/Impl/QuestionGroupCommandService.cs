using Application.Dto.Dictionary.QuestionGroup;
using Application.Exception;
using Application.Interfaces;
using Application.Specifications.Dictionary;
using AutoMapper;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Command.Impl;

public class QuestionGroupCommandService(IAsyncRepository<QuestionGroup> questionGroupAsyncRepository, IMapper mapper)
    : IQuestionGroupCommandService
{
    public async Task CreateAsync(QuestionGroupCreateDto createDto, CancellationToken cancellationToken)
    {
        if(createDto.Title.AllEmptyOrNull())
            throw new ApiException("Title should be filled");
        
        var spec = new QuestionGroupSpecification().ByTitle(createDto.Title);
        var exists = await questionGroupAsyncRepository.ExistAsync(spec, cancellationToken);
        if (exists)
            throw new ApiException("QuestionGroup with such title already exists");
        
        var questionGroup = mapper.Map<QuestionGroup>(createDto);
        await questionGroupAsyncRepository.AddAsync(questionGroup, cancellationToken);
    }

    public async Task UpdateAsync(Guid id, QuestionGroupUpdateDto updateDto, CancellationToken cancellationToken)
    {
        var questionGroup = await questionGroupAsyncRepository.GetByIdAsync(id, cancellationToken);
        if (questionGroup == null)
            throw new ApiException("QuestionGroup not found");
        
        if (updateDto.Title.AllEmptyOrNull())
            throw new ApiException("Title should be filled");
        
        mapper.Map(updateDto, questionGroup);
        await questionGroupAsyncRepository.UpdateAsync(questionGroup, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await questionGroupAsyncRepository.DeleteAsync(id, cancellationToken);
    }
}