using Manager.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class RoleMenuConfiguration : IEntityTypeConfiguration<RoleMenu>
    {
        public void Configure(EntityTypeBuilder<RoleMenu> builder)
        {
            builder.ToTable("RoleMenu", "System");
            builder.HasKey(x => new { x.RoleId, x.MenuId });
            builder.HasData(GetSeedData());
        }

        private RoleMenu[] GetSeedData()
        {
            var result = new RoleMenu[]
            {
            };

            return result;
        }
    }
}