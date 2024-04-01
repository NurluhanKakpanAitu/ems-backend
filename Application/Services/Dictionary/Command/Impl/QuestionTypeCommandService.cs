using Application.Dto.Dictionary.QuestionType;
using Application.Exception;
using Application.Interfaces;
using Application.Specifications.Dictionary;
using AutoMapper;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Command.Impl;

public class QuestionTypeCommandService : IQuestionTypeCommandService
{
    private readonly IAsyncRepository<QuestionType> _questionTypeAsyncRepository;
    private readonly IMapper _mapper;

    public QuestionTypeCommandService(
        IAsyncRepository<QuestionType> questionTypeAsyncRepository, 
        IMapper mapper)
    {
        _questionTypeAsyncRepository = questionTypeAsyncRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(QuestionTypeCreateDto createDto, CancellationToken cancellationToken = default)
    {
        if (createDto.Title.AllEmptyOrNull())
            throw new ApiException("Title should be filled");
        if(createDto.EmptyValue)
            throw new ApiException("Empty value should be filled");

        var spec = new QuestionTypeSpecification()
            .ByTitle(createDto.Title)
            .ByValue(createDto.Value);
        var exists = await _questionTypeAsyncRepository.ExistAsync(spec, cancellationToken);
        if (exists)
            throw new ApiException("Question type with such title and value already exists");
        
        var questionType = _mapper.Map<QuestionType>(createDto);
        await _questionTypeAsyncRepository.AddAsync(questionType, cancellationToken);
    }

    public async Task UpdateAsync(Guid id, QuestionTypeUpdateDto updateDto, CancellationToken cancellationToken = default)
    {
        var questionType = await _questionTypeAsyncRepository.GetByIdAsync(id, cancellationToken);
        if (questionType == null)
            throw new ApiException("Question type not found");
        if (updateDto.Title.AllEmptyOrNull())
            throw new ApiException("Title should be filled");
        if (updateDto.EmptyValue)
            throw new ApiException("Empty value should be filled");
        
        _mapper.Map(updateDto, questionType);
        await _questionTypeAsyncRepository.UpdateAsync(questionType, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _questionTypeAsyncRepository.DeleteAsync(id, cancellationToken);
    }
}