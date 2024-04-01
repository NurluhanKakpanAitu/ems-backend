using Application.Dto.Dictionary.QuestionGroup;

namespace Application.Services.Dictionary.Command;

public interface IQuestionGroupCommandService 
{
    Task CreateAsync(QuestionGroupCreateDto createDto, CancellationToken cancellationToken);
    
    Task UpdateAsync(Guid id, QuestionGroupUpdateDto updateDto, CancellationToken cancellationToken);
    
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}