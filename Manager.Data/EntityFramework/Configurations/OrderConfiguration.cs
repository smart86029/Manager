using Manager.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order", "GroupBuying");
            builder.Property(x => x.AmountPayable)
                .HasColumnType("decimal(19, 4)");
            builder.Property(x => x.AmountPaid)
                .HasColumnType("decimal(19, 4)");
            builder.HasOne(x => x.Creator)
                .WithMany()
                .HasForeignKey(x => x.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(GetSeedData());
        }

        private Order[] GetSeedData()
        {
            var result = new Order[]
            {
            };

            return result;
        }
    }
}