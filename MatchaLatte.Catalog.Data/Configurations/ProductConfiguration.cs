using MatchaLatte.Catalog.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Catalog.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(s => s.Description)
                .HasMaxLength(512);

            builder
                .HasOne(p => p.ProductCategory)
                .WithMany(x => x.Products)
                .HasForeignKey(p => p.ProductCategoryId);

            builder.Metadata
                .FindNavigation(nameof(Product.ProductItems))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasData(GetSeedData());
        }

        private object[] GetSeedData()
        {
            var result = new object[]
            {
            };

            return result;
        }
    }
}