using MatchaLatte.Ordering.Domain.Buyers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Ordering.Data.Configurations
{
    public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder
                .Property(b => b.FirstName)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(b => b.LastName)
                .IsRequired()
                .HasMaxLength(32);

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