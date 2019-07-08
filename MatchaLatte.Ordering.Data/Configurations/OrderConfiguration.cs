using MatchaLatte.Ordering.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Ordering.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(o => o.AmountPaid)
                .HasColumnType("decimal(19, 4)");

            builder.HasIndex(o => o.GroupId);

            builder.HasIndex(o => o.BuyerId);

            builder
                .HasMany(o => o.OrderItems)
                .WithOne()
                .HasForeignKey(i => i.OrderId);

            builder.Metadata
                .FindNavigation(nameof(Order.OrderItems))
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