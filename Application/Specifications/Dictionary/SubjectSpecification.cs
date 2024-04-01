using Application.Dto.Dictionary.Subject;
using Ardalis.Specification;
using Domain.Entity;
using Domain.Entity.Dictionary;

namespace Application.Specifications.Dictionary;

public class SubjectSpecification : Specification<Subject>
{
    public SubjectSpecification ByQuery(SubjectQuery query)
    {
        Query.Where(q => string.IsNullOrEmpty(query.Search) ||
                         (q.Title.Kk != null && q.Title.Kk.ToLower().Contains(query.Search.ToLower())) ||
                         (q.Title.Ru != null && q.Title.Ru.ToLower().Contains(query.Search.ToLower())) ||
                         (q.Title.En != null && q.Title.En.ToLower().Contains(query.Search.ToLower()))
        );
        return this;
    }
    
    public SubjectSpecification ByTitle(TranslationBaseEntity title)
    {
        Query.Where(q => q.Title == title);
        return this;
    }
}