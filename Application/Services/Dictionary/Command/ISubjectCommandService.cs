using Application.Dto.Dictionary.Subject;

namespace Application.Services.Dictionary.Command;

public interface ISubjectCommandService
{
    Task CreateAsync(SubjectCreateDto subjectCreateDto, CancellationToken cancellationToken = default);
    
    Task UpdateAsync(Guid id, SubjectUpdateDto subjectUpdateDto, CancellationToken cancellationToken = default);
    
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}