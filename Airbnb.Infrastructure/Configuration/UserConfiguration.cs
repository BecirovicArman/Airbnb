using Airbnb.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Airbnb.Infrastructure.Configuration;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name)
            .HasMaxLength(200);

        builder.Property(user => user.Email)
            .HasMaxLength(200);

        builder.HasIndex(user => user.Email).IsUnique();
    }
}