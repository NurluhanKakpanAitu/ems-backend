using Application.Dto.Dictionary.QuizType;
using Application.Exception;
using Application.Interfaces;
using Application.Specifications.Dictionary;
using AutoMapper;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Command.Impl;

public class QuizTypeCommandService(
    IAsyncRepository<QuizType> quizTypeAsyncRepository,
    IMapper mapper)
    : IQuizTypeCommandService
{
    public async Task CreateAsync(QuizTypeCreateDto createDto, CancellationToken cancellationToken)
    {
        if (createDto.Title.AllEmptyOrNull())
            throw new ApiException("Title should be filled");
        
        var spec = new QuizTypeSpecification().ByTitle(createDto.Title);
        var exists = await quizTypeAsyncRepository.ExistAsync(spec, cancellationToken);
        if (exists)
            throw new ApiException("Quiz type with such title already exists");
        
        var quizType = mapper.Map<QuizType>(createDto);
        await quizTypeAsyncRepository.AddAsync(quizType, cancellationToken);
    }

    public async Task UpdateAsync(Guid id, QuizTypeUpdateDto updateDto, CancellationToken cancellationToken)
    {
        var quizType = await quizTypeAsyncRepository.GetByIdAsync(id, cancellationToken);
        if (quizType == null)
            throw new ApiException("Quiz type not found");
        if (updateDto.Title.AllEmptyOrNull())
            throw new ApiException("Title should be filled");
        
        mapper.Map(updateDto, quizType);
        await quizTypeAsyncRepository.UpdateAsync(quizType, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await quizTypeAsyncRepository.DeleteAsync(id, cancellationToken);
    }
}