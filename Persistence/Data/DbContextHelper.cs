using Microsoft.EntityFrameworkCore;
using Persistence.Data.OnModelCreating;

namespace Persistence.Data;

public static class DbContextHelper
{
    public static void OnModelCreating(this ModelBuilder modelBuilder)
    {
        modelBuilder.DictionaryCreating();
        modelBuilder.QuizCreating();
        modelBuilder.UserCreating();
    }
}