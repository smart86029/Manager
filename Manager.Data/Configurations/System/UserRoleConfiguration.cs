using Manager.Domain.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.Configurations.System
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole", "System");
            builder.HasKey(x => new { x.UserId, x.RoleId });
            builder.HasData(GetSeedData());
        }

        private UserRole[] GetSeedData()
        {
            var result = new UserRole[]
            {
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 1, RoleId = 2 }
            };

            return result;
        }
    }
}