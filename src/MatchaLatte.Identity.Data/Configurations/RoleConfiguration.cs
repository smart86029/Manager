using MatchaLatte.Common.EntityFramework.Configurations;
using MatchaLatte.Identity.Domain.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Identity.Data.Configurations
{
    public class RoleConfiguration : EntityConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            builder
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.Metadata
                .FindNavigation(nameof(Role.UserRoles))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                .FindNavigation(nameof(Role.RolePermissions))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}