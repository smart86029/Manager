using MatchaLatte.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Identity.Data.Configurations
{
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder
                .Property(t => t.RefreshToken)
                .IsRequired()
                .HasColumnType("char(24)");

            builder
                .HasIndex(t => t.RefreshToken)
                .IsUnique();
        }
    }
}