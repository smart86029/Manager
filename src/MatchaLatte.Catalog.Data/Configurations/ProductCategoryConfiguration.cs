using MatchaLatte.Catalog.Domain.Stores;
using MatchaLatte.Common.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Catalog.Data.Configurations
{
    public class ProductCategoryConfiguration : EntityConfiguration<ProductCategory>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .HasOne(x => x.Store)
                .WithMany(s => s.ProductCategories)
                .HasForeignKey(x => x.StoreId);
        }
    }
}