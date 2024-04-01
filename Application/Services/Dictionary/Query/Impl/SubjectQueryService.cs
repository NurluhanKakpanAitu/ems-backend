using Application.Dto.Dictionary.Subject;
using Application.Exception;
using Application.Interfaces;
using Application.Specifications.Dictionary;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Query.Impl;

public class SubjectQueryService(IQueryRepository<Subject> subjectQueryRepository) : ISubjectQueryService
{
    public async Task<IEnumerable<Subject>> GetAllAsync(SubjectQuery query, CancellationToken cancellationToken = default)
    {
        var spec = new SubjectSpecification().ByQuery(query);
        var result = await subjectQueryRepository.ListAsync(spec, cancellationToken);
        return result;
    }

    public async Task<Subject> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var subject = await subjectQueryRepository.GetByIdAsync(id, cancellationToken);
        if (subject == null)
            throw new ApiException("Subject not found");
        return subject;
    }
}