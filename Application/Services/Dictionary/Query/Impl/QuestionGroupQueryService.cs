using Application.Dto.Dictionary.QuestionGroup;
using Application.Exception;
using Application.Interfaces;
using Application.Specifications.Dictionary;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Query.Impl;

public class QuestionGroupQueryService(IQueryRepository<QuestionGroup> questionGroupQueryRepository)
    : IQuestionGroupQueryService
{
    public async Task<IEnumerable<QuestionGroup>> GetAllAsync(QuestionGroupQuery query, CancellationToken cancellationToken)
    {
        var spec = new QuestionGroupSpecification().ByQuery(query);
        return await questionGroupQueryRepository.ListAsync(spec, cancellationToken);
    }

    public async Task<QuestionGroup> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var questionGroup = await questionGroupQueryRepository.GetByIdAsync(id, cancellationToken);
        if (questionGroup == null)
            throw new ApiException("QuestionGroup not found");
        
        return questionGroup;
    }
}