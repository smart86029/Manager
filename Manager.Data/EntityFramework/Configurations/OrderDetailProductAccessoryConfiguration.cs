using Manager.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class OrderDetailProductAccessoryConfiguration : IEntityTypeConfiguration<OrderDetailProductAccessory>
    {
        public void Configure(EntityTypeBuilder<OrderDetailProductAccessory> builder)
        {
            builder.ToTable("OrderDetailProductAccessory", "GroupBuying");
            builder.HasKey(x => new { x.OrderDetailId, x.ProductAccessoryId });
            builder.Property(x => x.ProductAccessoryName)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(x => x.ProductAccessoryPrice)
                .HasColumnType("decimal(19, 4)");
            builder.HasOne(x => x.ProductAccessory)
                .WithMany()
                .HasForeignKey(x => x.ProductAccessoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(GetSeedData());
        }

        private OrderDetailProductAccessory[] GetSeedData()
        {
            var result = new OrderDetailProductAccessory[]
            {
            };

            return result;
        }
    }
}