using Manager.Domain.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.Configurations.System
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasData(GetSeedData());
        }

        private Role[] GetSeedData()
        {
            var result = new Role[]
            {
                new Role(1, "Administrator", true),
                new Role(2, "HumanResources", true)
            };

            return result;
        }
    }
}