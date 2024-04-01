using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entity.Dictionary;

namespace Domain.Entity.Quiz;

public class Question : BaseEntity
{
    public Guid CreatedUserId { get; set; }

    public Guid UpdatedUserId { get; set; }
    
    [ForeignKey(nameof(QuestionGroup))]
    public Guid QuestionGroupId { get; set; }
    
    [ForeignKey(nameof(QuestionType))]
    public Guid QuestionTypeId { get; set; }


    public required string Locale { get; set; }
    
    
    public object? Config { get; set; }
    
    
    public required QuestionGroup QuestionGroup { get; set; }
    
    public required QuestionType QuestionType { get; set; }

    public List<Quiz> Quizzes { get; set; } = [];
    
    public List<QuizQuestion> QuizQuestions { get; set; } = [];
}