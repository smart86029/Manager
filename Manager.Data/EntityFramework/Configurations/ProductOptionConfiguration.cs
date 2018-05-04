using Manager.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class ProductOptionConfiguration : IEntityTypeConfiguration<ProductOption>
    {
        public void Configure(EntityTypeBuilder<ProductOption> builder)
        {
            builder.ToTable("ProductOption", "GroupBuying");
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasIndex(x => x.ProductOptionType);
            builder.HasData(GetSeedData());
        }

        private ProductOption[] GetSeedData()
        {
            var result = new ProductOption[]
            {
            };

            return result;
        }
    }
}