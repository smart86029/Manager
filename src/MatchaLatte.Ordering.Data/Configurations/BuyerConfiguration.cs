using MatchaLatte.Common.EntityFramework.Configurations;
using MatchaLatte.Ordering.Domain.Buyers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Ordering.Data.Configurations
{
    public class BuyerConfiguration : EntityConfiguration<Buyer>
    {
        public override void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(b => b.DisplayName)
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