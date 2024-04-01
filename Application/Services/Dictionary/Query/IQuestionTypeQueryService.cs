using Application.Dto.Dictionary.QuestionType;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Query;

public interface IQuestionTypeQueryService
{
    Task<IEnumerable<QuestionType>> GetAllAsync(QuestionTypeQuery query, CancellationToken cancellationToken = default);
    
    Task<QuestionType> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}