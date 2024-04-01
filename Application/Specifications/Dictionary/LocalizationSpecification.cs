using Application.Dto.Dictionary.Localization;
using Ardalis.Specification;
using Domain.Entity.Dictionary;

namespace Application.Specifications.Dictionary;

public class LocalizationSpecification : Specification<Localization>
{
    public LocalizationSpecification ByCode(string code)
    {
        Query.Where(q => q.Code == code);
        return this;
    }
    
    public LocalizationSpecification ByQuery(LocalizationQuery query)
    {
        Query.Where(q => string.IsNullOrEmpty(query.Search) || q.Code.Contains(query.Search) ||
                         (q.En != null && q.En.Contains(query.Search)) ||
                         (q.Ru != null && q.Ru.Contains(query.Search)) ||
                         (q.Kk != null && q.Kk.Contains(query.Search)));
        return this;
    }
}