using Application.Dto.Dictionary.Subject;
using Application.Exception;
using Application.Interfaces;
using Application.Specifications.Dictionary;
using AutoMapper;
using Domain.Entity.Dictionary;

namespace Application.Services.Dictionary.Command.Impl;

public class SubjectCommandService(
    IAsyncRepository<Subject> subjectAsyncRepository, 
    IMapper mapper)
    : ISubjectCommandService
{
    public async Task CreateAsync(SubjectCreateDto subjectCreateDto, CancellationToken cancellationToken = default)
    {
        if (subjectCreateDto.Title.AllEmptyOrNull())
            throw new ApiException("Title is required");
        var spec = new SubjectSpecification().ByTitle(subjectCreateDto.Title);
        var existingSubject = await subjectAsyncRepository.FirstOrDefaultAsync(spec, cancellationToken);
        if(existingSubject != null)
            throw new ApiException("Subject with the same title already exists");
        var subject = mapper.Map<Subject>(subjectCreateDto);
        await subjectAsyncRepository.AddAsync(subject, cancellationToken);
    }

    public async Task UpdateAsync(Guid id, SubjectUpdateDto subjectUpdateDto, CancellationToken cancellationToken = default)
    {
        if (subjectUpdateDto.Title.AllEmptyOrNull())
            throw new ApiException("Title is required");
        var subject = await subjectAsyncRepository.GetByIdAsync(id, cancellationToken);
        if (subject == null)
            throw new ApiException("Subject not found");
        mapper.Map(subjectUpdateDto, subject);
        await subjectAsyncRepository.UpdateAsync(subject, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var subject = await subjectAsyncRepository.GetByIdAsync(id, cancellationToken);
        if (subject == null)
            throw new ApiException("Subject not found");
        await subjectAsyncRepository.DeleteAsync(subject, cancellationToken);
    }
}