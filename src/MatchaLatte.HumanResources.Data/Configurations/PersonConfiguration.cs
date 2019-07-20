using MatchaLatte.HumanResources.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.HumanResources.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(p => p.BirthDate)
                .HasColumnType("date");
        }
    }
}