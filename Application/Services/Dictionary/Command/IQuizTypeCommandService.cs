using Application.Dto.Dictionary.QuizType;

namespace Application.Services.Dictionary.Command;

public interface IQuizTypeCommandService
{
    Task CreateAsync(QuizTypeCreateDto createDto, CancellationToken cancellationToken);
    
    Task UpdateAsync(Guid id, QuizTypeUpdateDto updateDto, CancellationToken cancellationToken);
    
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}