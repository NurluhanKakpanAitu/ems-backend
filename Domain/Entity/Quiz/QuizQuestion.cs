using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Quiz;

public class QuizQuestion : BaseEntity
{
    public required Quiz Quiz { get; set; }
    
    [ForeignKey(nameof(Quiz))]
    public Guid QuizId { get; set; }
    public required Question Question { get; set; }
    
    [ForeignKey(nameof(Question))]
    public Guid QuestionId { get; set; }
}