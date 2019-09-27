using MatchaLatte.Common.EntityFramework.Configurations;
using MatchaLatte.Ordering.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Ordering.Data.Configurations
{
    public class OrderItemProductAccessoryConfiguration : EntityConfiguration<OrderItemProductAccessory>
    {
        public override void Configure(EntityTypeBuilder<OrderItemProductAccessory> builder)
        {
            builder.HasIndex(x => x.ProductAccessoryId);

            builder
                .Property(x => x.ProductAccessoryName)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(x => x.ProductAccessoryPrice)
                .HasColumnType("decimal(19, 4)");

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