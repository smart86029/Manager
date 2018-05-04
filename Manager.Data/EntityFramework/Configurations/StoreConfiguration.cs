using System;
using Manager.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Store", "GroupBuying");
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(s => s.Description)
                .HasMaxLength(512);
            builder.Property(s => s.Phone)
                .HasMaxLength(32);
            builder.Property(s => s.Address)
                .HasMaxLength(128);
            builder.Property(s => s.Remark)
                .HasMaxLength(512);
            builder.HasOne(s => s.Creator)
                .WithMany()
                .HasForeignKey(s => s.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(GetSeedData());
        }

        private Store[] GetSeedData()
        {
            var result = new Store[]
            {
                new Store { StoreId = 1, Name = "韓膳宮", Description = "測試der", Phone = "2658-2882", Address = "台北市內湖區江南街117號", CreatedBy = 1, CreatedOn = DateTime.Now }
            };

            return result;
        }
    }
}