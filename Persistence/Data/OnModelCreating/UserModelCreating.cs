using Domain.Entity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data.OnModelCreating;

public static class UserModelCreating
{
    public static void UserCreating(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(ent => ent.ToTable("Users"));
        modelBuilder.Entity<IdentityRole>(ent => ent.ToTable("Roles"));
        modelBuilder.Entity<IdentityUserRole<string>>(ent => ent.ToTable("UserRoles"));
        modelBuilder.Entity<IdentityUserClaim<string>>(ent => ent.ToTable("UserClaims"));
        modelBuilder.Entity<IdentityUserLogin<string>>(ent => ent.ToTable("UserLogins"));
        modelBuilder.Entity<IdentityUserToken<string>>(ent => ent.ToTable("UserTokens"));
        modelBuilder.Entity<IdentityRoleClaim<string>>(ent => ent.ToTable("RoleClaims"));
    }
}