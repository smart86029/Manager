using MatchaLatte.Common.EntityFramework.Configurations;
using MatchaLatte.Identity.Domain.Permissions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Identity.Data.Configurations
{
    public class PermissionConfiguration : EntityConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);

            builder
                .Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .HasIndex(p => p.Code)
                .IsUnique();

            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(p => p.Description)
                .HasMaxLength(128);
        }
    }
}