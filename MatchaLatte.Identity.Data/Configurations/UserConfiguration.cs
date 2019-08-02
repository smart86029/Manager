using MatchaLatte.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Identity.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .HasIndex(u => u.UserName)
                .IsUnique();

            builder
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(32);

            builder.Metadata
                .FindNavigation(nameof(User.UserRoles))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(User.UserRefreshTokens))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}