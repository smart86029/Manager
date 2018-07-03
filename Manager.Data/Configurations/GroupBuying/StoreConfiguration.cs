using System;
using Manager.Domain.Models.Generic;
using Manager.Domain.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.Configurations.System
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Store");
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(s => s.Description)
                .HasMaxLength(512);
            builder.OwnsOne(s => s.Phone, x =>
            {
                x.Property(p => p.PhoneType).HasColumnName("PhoneType");
                x.Property(p => p.CountryCode).HasColumnName("CountryCode").IsRequired().HasMaxLength(4);
                x.Property(p => p.AreaCode).HasColumnName("AreaCode").IsRequired().HasMaxLength(4);
                x.Property(p => p.BaseNumber).HasColumnName("BaseNumber").IsRequired().HasMaxLength(8);
                x.Property(p => p.Extension).HasColumnName("Extension").IsRequired().HasMaxLength(8);
            });
            builder.OwnsOne(s => s.Address, x =>
            {
                x.Property(a => a.PostalCode).HasColumnName("PostalCode").IsRequired().HasMaxLength(8);
                x.Property(a => a.Country).HasColumnName("Country").IsRequired().HasMaxLength(32);
                x.Property(a => a.City).HasColumnName("City").IsRequired().HasMaxLength(32);
                x.Property(a => a.District).HasColumnName("District").IsRequired().HasMaxLength(32);
                x.Property(a => a.Street).HasColumnName("Street").IsRequired().HasMaxLength(128);
            });
            builder.Property(s => s.Remark)
                .HasMaxLength(512);

            //builder.HasData(GetSeedData());
        }

        private object[] GetSeedData()
        {
            var result = new object[]
            {
                new { StoreId = 1, Name = "Administrator", Description = "測試der", PhoneType = (int)PhoneType.Landline, CountryCode = "886", AreaCode = "02",
                    BaseNumber = "2658-2882", Extension = string.Empty, PostalCode = "11473", Country = "台灣", City = "台北市", District = "內湖區",
                    Street = "江南街117號", Remark = string.Empty, CreatedBy = 1, CreatedOn = DateTime.Now }
            };

            return result;
        }
    }
}