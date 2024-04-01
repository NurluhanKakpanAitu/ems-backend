using Application.Dto.Dictionary.QuestionType;
using Ardalis.Specification;
using Domain.Entity;
using Domain.Entity.Dictionary;

namespace Application.Specifications.Dictionary;

public class QuestionTypeSpecification : Specification<QuestionType>
{
    public QuestionTypeSpecification ById(Guid id)
    {
        Query.Where(q => q.Id == id);
        return this;
    }
    
    public QuestionTypeSpecification ByTitle(TranslationBaseEntity title)
    {
        Query.Where(q => q.Title == title);
        return this;
    }
    
    public QuestionTypeSpecification ByValue(string value)
    {
        Query.Where(q => q.Value == value);
        return this;
    }
    
    public QuestionTypeSpecification SearchByQuery(QuestionTypeQuery query)
    {
        var title = query.Search;
        Query.Where(q => string.IsNullOrEmpty(title) ||
                         (q.Title.Kk != null && q.Title.Kk.ToLower().Contains(title.ToLower())) ||
                         (q.Title.Ru != null && q.Title.Ru.ToLower().Contains(title.ToLower())) ||
                         (q.Title.En != null && q.Title.En.ToLower().Contains(title.ToLower())) ||
                         q.Value.ToLower().Contains(title.ToLower()));
        return this;
    }
}