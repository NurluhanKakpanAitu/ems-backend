using Application.Dto.Dictionary.QuizType;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Query;

public interface IQuizTypeQueryService
{
    Task<IEnumerable<QuizType>> GetAllAsync(QuizTypeQuery query, CancellationToken cancellationToken);
    
    Task<QuizType> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}