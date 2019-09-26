using MatchaLatte.Common.EntityFramework.Configurations;
using MatchaLatte.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Identity.Data.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder
                .Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .HasIndex(u => u.UserName)
                .IsUnique();

            builder
                .Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(256);

            builder
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(u => u.DisplayName)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}