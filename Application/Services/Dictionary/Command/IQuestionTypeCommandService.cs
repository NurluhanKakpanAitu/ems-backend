using Application.Dto.Dictionary.QuestionType;

namespace Application.Services.Dictionary.Command;

public interface IQuestionTypeCommandService
{
    Task CreateAsync(QuestionTypeCreateDto createDto, CancellationToken cancellationToken = default);
    
    Task UpdateAsync(Guid id, QuestionTypeUpdateDto updateDto, CancellationToken cancellationToken = default);
    
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}