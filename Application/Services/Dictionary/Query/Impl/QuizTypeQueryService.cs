using Application.Dto.Dictionary.QuizType;
using Application.Exception;
using Application.Interfaces;
using Application.Specifications.Dictionary;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Query.Impl;

public class QuizTypeQueryService(IQueryRepository<QuizType> quizTypeQueryRepository) : IQuizTypeQueryService
{
    public async Task<IEnumerable<QuizType>> GetAllAsync(QuizTypeQuery query, CancellationToken cancellationToken)
    {
        var spec = new QuizTypeSpecification().ByQuery(query);
        return await quizTypeQueryRepository.ListAsync(spec, cancellationToken);
    }

    public async Task<QuizType> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var quizType = await quizTypeQueryRepository.GetByIdAsync(id, cancellationToken);
        if (quizType == null)
            throw new ApiException("Quiz type not found");
        return quizType;
    }
}