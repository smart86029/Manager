using Manager.Domain.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.Configurations.System
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory");
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasOne(x => x.Store)
                .WithMany(s => s.ProductCategories)
                .HasForeignKey(x => x.StoreId);
            builder.Metadata.FindNavigation(nameof(ProductCategory.Products))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            //builder.HasData(GetSeedData());
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