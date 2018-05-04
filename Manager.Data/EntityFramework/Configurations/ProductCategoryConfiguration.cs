using Manager.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory", "GroupBuying");
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasData(GetSeedData());
        }

        private ProductCategory[] GetSeedData()
        {
            var result = new ProductCategory[]
            {
                new ProductCategory { ProductCategoryId = 1, Name = "飯類", StoreId = 1 },
                new ProductCategory { ProductCategoryId = 2, Name = "鍋類", StoreId = 1 },
                new ProductCategory { ProductCategoryId = 3, Name = "特色餐點", StoreId = 1 },
            };

            return result;
        }
    }
}