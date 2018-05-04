using Manager.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.ToTable("ProductItem", "GroupBuying");
            builder.Property(i => i.Name)
                .HasMaxLength(32);
            builder.Property(i => i.Price)
                .HasColumnType("decimal(19, 4)");
            builder.HasData(GetSeedData());
        }

        private ProductItem[] GetSeedData()
        {
            var result = new ProductItem[]
            {
                new ProductItem { ProductItemId = 1, Price = 90, ProductId = 1 },
                new ProductItem { ProductItemId = 2, Price = 90, ProductId = 1 },
                new ProductItem { ProductItemId = 3, Price = 90, ProductId = 1 },
                new ProductItem { ProductItemId = 4, Price = 90, ProductId = 1 },
                new ProductItem { ProductItemId = 5, Price = 90, ProductId = 1 },
                new ProductItem { ProductItemId = 6, Price = 130, ProductId = 1 },
                new ProductItem { ProductItemId = 7, Price = 130, ProductId = 1 },
                new ProductItem { ProductItemId = 8, Price = 130, ProductId = 1 },
                new ProductItem { ProductItemId = 9, Price = 130, ProductId = 1 },
                new ProductItem { ProductItemId = 10, Price = 130, ProductId = 1 },
                new ProductItem { ProductItemId = 11, Price = 130, ProductId = 1 },
                new ProductItem { ProductItemId = 12, Price = 150, ProductId = 1 },
                new ProductItem { ProductItemId = 13, Price = 100, ProductId = 1 },
                new ProductItem { ProductItemId = 14, Price = 140, ProductId = 1 },
                new ProductItem { ProductItemId = 15, Price = 130, ProductId = 1 },
                new ProductItem { ProductItemId = 16, Price = 150, ProductId = 1 },
            };

            return result;
        }
    }
}