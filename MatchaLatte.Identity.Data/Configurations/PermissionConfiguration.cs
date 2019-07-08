using System;
using MatchaLatte.Common.Utilities;
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
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(64);

            builder.HasData(GetSeedData());
        }

        private Permission[] GetSeedData()
        {
            var result = new Permission[]
            {
                new Permission("特殊權限", string.Empty, true),
                new Permission("登入", string.Empty, true)
            };

            return result;
        }
    }
}