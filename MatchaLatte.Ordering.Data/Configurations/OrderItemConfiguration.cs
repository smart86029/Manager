using MatchaLatte.Ordering.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Ordering.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasIndex(i => i.ProductItemId);

            builder
                .Property(i => i.ProductItemName)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(i => i.ProductItemPrice)
                .HasColumnType("decimal(19, 4)");

            builder
                .HasMany(i => i.OrderItemProductAccessories)
                .WithOne()
                .HasForeignKey(x => x.OrderItemId);

            builder.Metadata
                .FindNavigation(nameof(OrderItem.OrderItemProductAccessories))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasData(GetSeedData());
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