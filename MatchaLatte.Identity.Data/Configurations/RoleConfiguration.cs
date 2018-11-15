using System;
using MatchaLatte.Common.Utilities;
using MatchaLatte.Identity.Domain.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Identity.Data.Configurations
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
                new Role(GuidUtility.NewGuid(), "Administrator", true),
                new Role(GuidUtility.NewGuid(), "HumanResources", true)
            };

            return result;
        }
    }
}