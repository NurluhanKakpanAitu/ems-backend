using Domain.Entity.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(p => p.UserName).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(50).IsRequired();
        builder.Property(p => p.PasswordHash).HasMaxLength(1000).IsRequired();
        builder.Property(p => p.BirthDate).IsRequired(false);
        builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
    }
}