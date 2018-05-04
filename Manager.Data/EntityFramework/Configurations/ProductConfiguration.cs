using Manager.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "GroupBuying");
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(p => p.Description)
                .HasMaxLength(64);
            builder.HasData(GetSeedData());
        }

        private Product[] GetSeedData()
        {
            var result = new Product[]
            {
                new Product { ProductId = 1, Name = "韓式牛肉烤肉飯", ProductCategoryId = 1 },
                new Product { ProductId = 2, Name = "韓式豬肉烤肉飯", ProductCategoryId = 1 },
                new Product { ProductId = 3, Name = "韓式牛肉拌飯", ProductCategoryId = 1 },
                new Product { ProductId = 4, Name = "韓式豬肉拌飯", ProductCategoryId = 1 },
                new Product { ProductId = 5, Name = "韓式辣雞拌飯", ProductCategoryId = 1 },
                new Product { ProductId = 6, Name = "香腸泡菜炒飯", ProductCategoryId = 1 },
                new Product { ProductId = 7, Name = "鮪魚泡菜炒飯", ProductCategoryId = 1 },
                new Product { ProductId = 8, Name = "海鮮豆腐鍋", ProductCategoryId = 2 },
                new Product { ProductId = 9, Name = "海鮮泡菜鍋", ProductCategoryId = 2 },
                new Product { ProductId = 10, Name = "大醬湯飯鍋", ProductCategoryId = 2 },
                new Product { ProductId = 11, Name = "豆腐辣湯鍋", ProductCategoryId = 2 },
                new Product { ProductId = 12, Name = "部隊鍋", ProductCategoryId = 2 },
                new Product { ProductId = 13, Name = "辣炒泡麵", ProductCategoryId = 3 },
                new Product { ProductId = 14, Name = "海鮮炒麵", ProductCategoryId = 3 },
                new Product { ProductId = 15, Name = "辣炒年糕", ProductCategoryId = 3 },
                new Product { ProductId = 16, Name = "海鮮煎餅", ProductCategoryId = 3 },
            };

            return result;
        }
    }
}