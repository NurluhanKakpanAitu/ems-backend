using Application.Dto.Dictionary.Subject;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Query;

public interface ISubjectQueryService
{
    Task<IEnumerable<Subject>> GetAllAsync(SubjectQuery query, CancellationToken cancellationToken = default);
    
    Task<Subject> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}