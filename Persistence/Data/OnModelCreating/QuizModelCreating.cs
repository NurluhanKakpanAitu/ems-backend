using Domain.Entity.Quiz;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data.OnModelCreating;

public static class QuizModelCreating
{
    public static void QuizCreating(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>(q => q.Property(x => x.Config).HasColumnType("jsonb"));
    }
}