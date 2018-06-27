using Manager.Domain.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.Configurations.System
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission", "System");
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(64);
            builder.HasData(GetSeedData());
        }

        private Permission[] GetSeedData()
        {
            var result = new Permission[]
            {
                new Permission { PermissionId = 1, Name = "特殊權限", Description = "", IsEnabled = true },
                new Permission { PermissionId = 2, Name = "登入", Description = "", IsEnabled = true },
            };

            return result;
        }
    }
}