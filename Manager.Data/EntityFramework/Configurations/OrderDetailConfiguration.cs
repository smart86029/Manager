using Manager.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail", "GroupBuying");
            builder.Property(x => x.ProductItemName)
                .HasMaxLength(64);
            builder.Property(x => x.ProductItemPrice)
                .HasColumnType("decimal(19, 4)");
            builder.HasData(GetSeedData());
        }

        private OrderDetail[] GetSeedData()
        {
            var result = new OrderDetail[]
            {
            };

            return result;
        }
    }
}