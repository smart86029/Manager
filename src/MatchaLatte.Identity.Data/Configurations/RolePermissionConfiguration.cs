using MatchaLatte.Common.EntityFramework.Configurations;
using MatchaLatte.Identity.Domain.Roles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Identity.Data.Configurations
{
    public class RolePermissionConfiguration : EntityConfiguration<RolePermission>
    {
        public override void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            base.Configure(builder);
        }
    }
}