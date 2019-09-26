using MatchaLatte.Catalog.Domain.Products;
using MatchaLatte.Common.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Catalog.Data.Configurations
{
    public class ProductConfiguration : EntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
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
        }
    }
}