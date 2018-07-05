using Manager.Domain.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.Configurations.System
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(s => s.Description)
                .HasMaxLength(512);
            builder.HasOne(p => p.ProductCategory)
                .WithMany(x => x.Products)
                .HasForeignKey(p => p.ProductCategoryId);

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