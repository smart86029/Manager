using MatchaLatte.Common.EntityFramework.Configurations;
using MatchaLatte.HumanResources.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.HumanResources.Data.Configurations
{
    public class PersonConfiguration : EntityConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(p => p.DisplayName)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(p => p.BirthDate)
                .HasColumnType("date");
        }
    }
}