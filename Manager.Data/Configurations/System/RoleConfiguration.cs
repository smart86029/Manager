using Manager.Domain.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.Configurations.System
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role", "System");
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasData(GetSeedData());
        }

        private Role[] GetSeedData()
        {
            var result = new Role[]
            {
                new Role { RoleId = 1, Name = "Administrator", IsEnabled = true },
                new Role { RoleId = 2, Name = "HumanResources", IsEnabled = true }
            };

            return result;
        }
    }
}