using Application.Dto.Dictionary.QuestionGroup;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Query;

public interface IQuestionGroupQueryService
{
    Task<IEnumerable<QuestionGroup>> GetAllAsync(QuestionGroupQuery query, CancellationToken cancellationToken);
    
    Task<QuestionGroup> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}