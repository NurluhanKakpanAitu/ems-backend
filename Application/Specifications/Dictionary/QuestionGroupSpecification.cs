using Application.Dto.Dictionary.QuestionGroup;
using Ardalis.Specification;
using Domain.Entity;
using Domain.Entity.Dictionary;

namespace Application.Specifications.Dictionary;

public class QuestionGroupSpecification : Specification<QuestionGroup>
{
    public QuestionGroupSpecification ById(Guid id)
    {
        Query.Where(x => x.Id == id);
        return this;
    }
    
    public QuestionGroupSpecification ByTitle(TranslationBaseEntity title)
    {
        Query.Where(x => x.Title == title);
        return this;
    }
    
    public QuestionGroupSpecification ByQuery(QuestionGroupQuery query)
    {
        Query.Where(x => string.IsNullOrEmpty(query.Search) || 
                         ( x.Title.Kk != null && x.Title.Kk.ToLower().Contains(query.Search.ToLower())) ||
                         ( x.Title.Ru != null &&  x.Title.Ru.ToLower().Contains(query.Search.ToLower())) ||
                         ( x.Title.En != null && x.Title.En.ToLower().Contains(query.Search.ToLower())));
        return this;
    }
}