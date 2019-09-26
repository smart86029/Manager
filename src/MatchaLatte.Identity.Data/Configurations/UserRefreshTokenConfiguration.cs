using MatchaLatte.Common.EntityFramework.Configurations;
using MatchaLatte.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Identity.Data.Configurations
{
    public class UserRefreshTokenConfiguration : EntityConfiguration<UserRefreshToken>
    {
        public override void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            base.Configure(builder);

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