using Domain.Entity.Dictionary;
using Domain.Entity.Quiz;
using Domain.Entity.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Configuration;

namespace Persistence.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Localization> DicLocalizations { get; set; }
    
    public DbSet<Subject> DicSubjects { get; set; }
    
    public DbSet<QuestionType> DicQuestionTypes { get; set; }
    
    public DbSet<QuizType> DicQuizTypes { get; set; }
    
    public DbSet<Question> Questions { get; set; }
    
    public DbSet<Quiz> Quizzes { get; set; }
    
    public DbSet<QuizQuestion> QuizQuestions { get; set; }
    
    public DbSet<QuestionGroup> DicQuestionGroups { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.OnModelCreating();
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
    }
}