using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Dictionary;
using Domain.Enums;

namespace Domain.Entity.Quiz;

public class Quiz : BaseEntity
{
    public required string Title { get; set; }

    public required string Locale { get; set; }

    [ForeignKey(nameof(QuizType))]
    public Guid QuizTypeId { get; set; }

    public QuizStatus QuizStatus { get; set; }
    
    [ForeignKey(nameof(Subject))]
    public Guid SubjectId { get; set; }
    
    public DateTime StartTime { get; set; }
    
    public int Duration { get; set; }
    
    public required QuizType QuizType { get; set; }
    
    public required Subject Subject { get; set; }

    public List<QuizQuestion> QuizQuestions { get; set; } = [];

    public List<Question> Questions { get; set; } = [];
}