using Manager.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu", "System");
            builder.HasOne(m => m.Parent)
                .WithMany()
                .HasForeignKey(m => m.ParentId);
            builder.HasData(GetSeedData());
        }

        private Menu[] GetSeedData()
        {
            var result = new Menu[]
            {
            };

            return result;
        }
    }
}