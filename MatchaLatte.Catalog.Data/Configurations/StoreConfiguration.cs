using MatchaLatte.Catalog.Domain.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Catalog.Data.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(s => s.Description)
                .HasMaxLength(512);

            builder.OwnsOne(s => s.Logo, innerBuilder =>
            {
                innerBuilder
                    .Property(p => p.FileName)
                    .HasColumnName("LogoFileName")
                    .IsRequired()
                    .HasMaxLength(256);
            });

            builder.OwnsOne(s => s.Phone, innerBuilder =>
            {
                innerBuilder
                    .Property(p => p.PhoneType)
                    .HasColumnName("PhoneType");

                innerBuilder
                    .Property(p => p.CountryCode)
                    .HasColumnName("CountryCode")
                    .IsRequired()
                    .HasMaxLength(4);

                innerBuilder
                    .Property(p => p.PhoneNumber)
                    .HasColumnName("PhoneNumber")
                    .IsRequired()
                    .HasMaxLength(32);
            });

            builder.OwnsOne(s => s.Address, innerBuilder =>
            {
                innerBuilder
                    .Property(a => a.PostalCode)
                    .HasColumnName("PostalCode")
                    .IsRequired()
                    .HasMaxLength(8);

                innerBuilder
                    .Property(a => a.Country)
                    .HasColumnName("Country")
                    .IsRequired()
                    .HasMaxLength(32);

                innerBuilder
                    .Property(a => a.City)
                    .HasColumnName("City")
                    .IsRequired()
                    .HasMaxLength(32);

                innerBuilder
                    .Property(a => a.District)
                    .HasColumnName("District")
                    .IsRequired()
                    .HasMaxLength(32);

                innerBuilder
                    .Property(a => a.Street)
                    .HasColumnName("Street")
                    .IsRequired()
                    .HasMaxLength(128);
            });

            builder
                .Property(s => s.Remark)
                .HasMaxLength(512);

            builder.Metadata
                .FindNavigation(nameof(Store.ProductCategories))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}