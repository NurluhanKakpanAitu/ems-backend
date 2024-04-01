using Application.Dto.Dictionary.QuizType;
using Ardalis.Specification;
using Domain.Entity;
using Domain.Entity.Dictionary;

namespace Application.Specifications.Dictionary;

public class QuizTypeSpecification : Specification<QuizType>
{
    public QuizTypeSpecification ById(Guid id)
    {
        Query.Where(q => q.Id == id);
        return this;
    }
    public QuizTypeSpecification ByTitle(TranslationBaseEntity title)
    {
        Query.Where(q => q.Title == title);
        return this;
    }

    public QuizTypeSpecification ByQuery(QuizTypeQuery query)
    {
        Query.Where(q => string.IsNullOrEmpty(query.Search) || 
                         ( q.Title.Kk != null && q.Title.Kk.ToLower().Contains(query.Search.ToLower())) ||
                         ( q.Title.Ru != null &&  q.Title.Ru.ToLower().Contains(query.Search.ToLower())) ||
                         ( q.Title.En != null && q.Title.En.ToLower().Contains(query.Search.ToLower())));
        return this;
    }
    
}