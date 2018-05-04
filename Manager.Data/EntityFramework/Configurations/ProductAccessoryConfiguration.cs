using Manager.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class ProductAccessoryConfiguration : IEntityTypeConfiguration<ProductAccessory>
    {
        public void Configure(EntityTypeBuilder<ProductAccessory> builder)
        {
            builder.ToTable("ProductAccessory", "GroupBuying");
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(a => a.Price)
                .HasColumnType("decimal(19, 4)");
            builder.HasData(GetSeedData());
        }

        private ProductAccessory[] GetSeedData()
        {
            var result = new ProductAccessory[]
            {
            };

            return result;
        }
    }
}