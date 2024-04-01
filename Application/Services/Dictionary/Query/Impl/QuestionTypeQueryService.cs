using Application.Dto.Dictionary.QuestionType;
using Application.Exception;
using Application.Interfaces;
using Application.Specifications.Dictionary;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Query.Impl;

public class QuestionTypeQueryService(IQueryRepository<QuestionType> questionTypeQueryRepository)
    : IQuestionTypeQueryService
{
    public async Task<IEnumerable<QuestionType>> GetAllAsync(QuestionTypeQuery query, CancellationToken cancellationToken = default)
    {
        var spec = new QuestionTypeSpecification().SearchByQuery(query);
        return await questionTypeQueryRepository.ListAsync(spec, cancellationToken);
    }

    public async Task<QuestionType> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var questionType = await questionTypeQueryRepository.GetByIdAsync(id, cancellationToken);
        if (questionType == null)
            throw new ApiException("Question type not found");
        return questionType;
    }
}