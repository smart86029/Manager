using MatchaLatte.Identity.Domain.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Identity.Data.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
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