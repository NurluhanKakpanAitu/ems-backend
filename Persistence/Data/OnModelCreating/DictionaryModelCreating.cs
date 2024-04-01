using Domain.Entity;
using Domain.Entity.Dictionary;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Persistence.Data.OnModelCreating;

public static class DictionaryModelCreating
{
    public static void DictionaryCreating(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Subject>()
            .Property(q => q.Title)
            .HasColumnType("jsonb");

        modelBuilder.Entity<QuestionType>()
            .Property(q => q.Title)
            .HasColumnType("jsonb");

        modelBuilder.Entity<QuizType>()
            .Property(q => q.Title)
            .HasColumnType("jsonb");

        modelBuilder.Entity<QuestionGroup>()
            .Property(q => q.Title)
            .HasColumnType("jsonb");
    }
}